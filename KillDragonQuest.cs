namespace QuestsSystem
{
    public class KillDragonQuest : Quest
    {
        public KillDragonQuest(int id, Agreement agreement, QuestEvent questEvent) 
            : base(id, agreement, questEvent)
        {
            Description = "Kill the angry dragon.";
            Question = "You kill angry dragon?";
        }
    }
}