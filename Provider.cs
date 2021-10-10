using System;
using System.Linq;

namespace QuestsSystem
{
    public class Provider
    {
        private readonly QuestsRepository _questsRepository;
        private readonly PlayerQuestRepository _playerQuestRepository;
        private readonly Player _player;

        public Provider(QuestsRepository questsRepository, Player player, PlayerQuestRepository playerQuestRepository)
        {
            _questsRepository = questsRepository;
            _player = player;
            _playerQuestRepository = playerQuestRepository;
        }
        public void Subscribe()
        {
            _player.OnTouchNpc += GetNpcQuests;
        }

        public void Unsubscribe()
        {
            _player.OnTouchNpc -= GetNpcQuests;
        }

        private Quest FindQuestFromNpc(Npc npc)
        {
            return _playerQuestRepository.HasQuestFromNpc(npc.GetType());
        }

        private void GetNpcQuests(Npc npc)
        {
            var type = npc.GetType();
            if (!type.GetInterfaces().Contains(typeof(IQuestGiver))) return;
            
            var npcQuests = _questsRepository.GetQuests(npc.GetType()).OrderBy(quest => quest.LocalId).ToArray();
            
            foreach (var quest in npcQuests)
            {
                Console.WriteLine(quest.LocalId + ". " + quest.Description + "Taken:" + quest.Agreement.QuestEvent.QuestStatus);
            }
            //get quest from playerQuest repository
            var npcQuest = FindQuestFromNpc(npc);
            //
            var complete = CheckCompleteCondition(npcQuest);
            
            if(!complete)
            {
                if (npcQuest?.GetType() == typeof(EmptyQuest))
                    BringQuestToPlayer(npc, npcQuests[0]);
                else
                    Console.WriteLine(npcQuest?.Question);
            }        
        }

        private bool CheckCompleteCondition(Quest npcQuest)
        {
            if (npcQuest != null && npcQuest.GetType() != typeof(EmptyQuest))
            {
                npcQuest.Agreement.CompleteCondition();
                return true;
            }

            return false;
        }

        public void GetPlayerNotCompletionQuests(Npc npc)
        {
            var notCompletionQuests = Array.Empty<Quest>();
            
            var type = npc.GetType();
            if(type.GetInterfaces().Contains(typeof(IQuestGiver)))
            {
                notCompletionQuests = _playerQuestRepository.GetNotCompletionQuest();
            }
        }
        public void GetPlayerCompletionQuests(Npc npc)
        {
            var playerCompleteionQuests = Array.Empty<Quest>();
            
            var type = npc.GetType();
            if(type.GetInterfaces().Contains(typeof(IQuestGiver)))
            {
                playerCompleteionQuests = _playerQuestRepository.GetCompletionQuest();
            }
        }

        private Quest BringQuestToPlayer(Npc npc, Quest quest)
        {
            quest.Agreement.QuestEvent.UpdateStatus(Status.Active);
            _playerQuestRepository.AddQuest(npc.GetType(), quest);
            return quest;
        }
    }
}