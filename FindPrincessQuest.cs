namespace QuestsSystem
{
    public class FindPrincessQuest : Quest
    {
        public FindPrincessQuest(int id, Agreement agreement, QuestEvent questEvent) 
            : base(id, agreement, questEvent)
        {
            Description = "Find pretty princess in the forest.";
            Question = "You find princess?";
        }
    }
}