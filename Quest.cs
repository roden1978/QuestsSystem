namespace QuestsSystem
{
    public abstract class Quest
    {
        private readonly Agreement _agreement;
        private readonly QuestEvent _questEvent;

        protected Quest(int id, Agreement agreement, QuestEvent questEvent)
        {
            LocalId = id;
            _agreement = agreement;
            _questEvent = questEvent;
        }

        public int LocalId { get; }
        public string Description { get; protected init;}
        public string Question { get; protected init;}

        public Agreement Agreement => _agreement;
        public QuestEvent QuestEvent => _questEvent;

        public Status GetStatus()
        {
            return _questEvent.QuestStatus;
        }
        
        public void CheckCompleteQuest(Marker[] markers)
        {
            var currentStatus = GetStatus();
            var newStatus = _agreement.CompleteCondition(currentStatus, markers);
            _questEvent.UpdateStatus(newStatus);
        }
    }
}