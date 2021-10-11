namespace QuestsSystem
{
    public class CollectApplesQuest : Quest
    {
        public CollectApplesQuest(int id, Agreement agreement, QuestEvent questEvent) 
            : base(id, agreement, questEvent)
        {
            Description = "Collect 5 apples for me!";
            Question = "You bring me 5 apples";
        }
    }
}