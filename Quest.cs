namespace QuestsSystem
{
    public abstract class Quest
    {
        private readonly Agreement _agreement;

        protected Quest(int id, Agreement agreement)
        {
            LocalId = id;
            _agreement = agreement;
            Status = Status.Waiting;
        }

        public int LocalId { get; }
        public string Description { get; protected init;}
        public string Question { get; protected init;}
        public Status Status { get; private set; }


        public Status GetStatus()
        {
            return Status;
        }
        public void UpdateStatus(Status status)
        {
            Status = status;
        }
        
        public void CheckCompleteQuest(Marker[] markers)
        {
            var currentStatus = GetStatus();
            var newStatus = _agreement.CompleteCondition(currentStatus, markers);
            UpdateStatus(newStatus);
        }
    }
}