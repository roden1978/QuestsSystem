namespace QuestsSystem
{
    public class KillDragonQuest : Quest
    {
        public KillDragonQuest(int id, Agreement agreement) : base(id, agreement)
        {
            Description = "Kill the angry dragon.";
            Question = "You kill angry dragon?";
        }
    }
}