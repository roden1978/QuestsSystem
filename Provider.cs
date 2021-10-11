using System;
using System.Linq;

namespace QuestsSystem
{
    public class Provider
    {
        private readonly QuestsRepository _questsRepository;
        private readonly MarkerRepository _markerRepository;
        private readonly Player _player;

        public Provider(Player player, QuestsRepository questsRepository, MarkerRepository markerRepository)
        {
            _questsRepository = questsRepository;
            _markerRepository = markerRepository;
            _player = player;
        }
        public void Subscribe()
        {
            _player.OnTouchNpc += GetNpcQuests;
            _player.OnMarkedItemTouch += AddMarkerToRepository;
        }

        public void Unsubscribe()
        {
            _player.OnTouchNpc -= GetNpcQuests;
            _player.OnMarkedItemTouch -= AddMarkerToRepository;
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
                Console.WriteLine(quest.LocalId + ". " + quest.Description + "Taken:" + quest.Status);
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
                var questsMarkers = _markerRepository.GetAllMarkers();
                npcQuest.CheckCompleteQuest(questsMarkers);
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
            quest.UpdateStatus(Status.Active);
        }
        
       
        private void AddMarkerToRepository(GameObject markedItem)
        {
            _markerRepository.AddMarker(markedItem.Marker);
        }
    }
}