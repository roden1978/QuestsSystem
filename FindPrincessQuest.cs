namespace QuestsSystem
{
    public class FindPrincessQuest : Quest
    {
        public FindPrincessQuest(int id, Agreement agreement) 
            : base(id, agreement)
        {
            Description = "Find pretty princess in the forest.";
            Question = "You find princess?";
        }
    }
}