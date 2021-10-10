using System;
using System.Collections.Generic;

namespace QuestsSystem
{
    public  class PlayerQuestRepository
    {
        private readonly Dictionary<Type, Quest> _playerQuests;
        public PlayerQuestRepository()
        {
            _playerQuests = new Dictionary<Type, Quest>();
        }
        public void AddQuest (Type npc, Quest quest)
        {
            _playerQuests.Add(npc, quest);
        }
        
        public Quest[] GetNotCompletionQuest()
        {
            var notCompletionQuests = new List<Quest>();
            
            foreach (var (_, value) in _playerQuests)
            {
                if (value.Agreement.QuestEvent.QuestStatus != Status.Done)
                    notCompletionQuests.Add(value);
            }

            return notCompletionQuests.ToArray();
        }
        
        public Quest[] GetCompletionQuest()
        {
            var completionQuests = new List<Quest>();
            
            foreach (var (_, value) in _playerQuests)
            {
               if (value.Agreement.QuestEvent.QuestStatus == Status.Done)
                 completionQuests.Add(value);
            }

            return completionQuests.ToArray();
        }

        public Quest HasQuestFromNpc(Type npc)
        {
            foreach (var (key, value) in _playerQuests)
            {
                if (key == npc)
                    return value;
            }

            return new EmptyQuest();
        }
    }
}