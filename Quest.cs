namespace QuestsSystem
{
    public abstract class Quest
    {
        private Agreement _agreement;

        protected Quest(int id, Agreement agreement)
        {
            LocalId = id;
            _agreement = agreement;
        }

        public int LocalId { get; }
        public string Description { get; protected init;}
        public string Question { get; protected init;}

        public Agreement Agreement => _agreement;
    }
}