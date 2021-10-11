using System;
using System.Linq;

namespace QuestsSystem
{
    public class Provider
    {
        private readonly QuestsRepository _questsRepository;
        private readonly Player _player;

        public Provider(QuestsRepository questsRepository, Player player)
        {
            _questsRepository = questsRepository;
            _player = player;
        }
        public void Subscribe()
        {
            _player.OnTouchNpc += GetNpcQuests;
        }

        public void Unsubscribe()
        {
            _player.OnTouchNpc -= GetNpcQuests;
        }

        private Quest GetActiveQuestFromNpc(Npc npc)
        {
            return _questsRepository.GetQuestFromNpc(npc);
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
            var npcQuest = GetActiveQuestFromNpc(npc);
            
            var complete = CheckCompleteCondition(npcQuest);
            
            if(!complete)
            {
                if (npcQuest?.GetType() == typeof(EmptyQuest))
                    BringQuestToPlayer(npcQuests.First());
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

        public Quest[] GetAllQuestsWithStatus(Status status)
        {
            return _questsRepository.GetQuestsWithStatus(status);
        }
       
        private void BringQuestToPlayer(Quest quest)
        {
            quest.Agreement.QuestEvent.UpdateStatus(Status.Active);
        }
    }
}