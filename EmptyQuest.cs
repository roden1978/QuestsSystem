namespace QuestsSystem
{
    public class EmptyQuest : Quest
    {
        public EmptyQuest() : base(-1, null)
        {
            Description = "Empty quest";
        }
    }
}