using System;
using System.Collections.Generic;

namespace QuestsSystem
{
    public class QuestsRepository
    {
        private readonly Dictionary<Type, Quest[]> _quests;

        public QuestsRepository(Dictionary<Type, Quest[]> quests)
        {
            _quests = quests;
        }
        public void AddQuest (Type npc, Quest[] quest)
        {
            _quests.Add(npc, quest);
        }

        public Quest[] GetQuests(Type npc)
        {
            var npcQuests = new List<Quest>();
            foreach (var (key, value) in _quests)
            {
                if(key == npc)
                {
                    foreach (var quest in value)
                    {
                        if(quest.Agreement.QuestEvent.QuestStatus != Status.Active && 
                           quest.Agreement.QuestEvent.QuestStatus != Status.Active)
                            npcQuests.Add(quest);
                    }
                    
                }                
            }

            return npcQuests.ToArray();
        }
    }
}