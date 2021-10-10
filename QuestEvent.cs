namespace QuestsSystem
{
    public abstract class QuestEvent
    {
        private Status _status;
        private Marker _marker;
        protected QuestEvent(Marker marker)
        {
            _status = Status.Waiting;
            _marker = marker;
        }
        
        public void UpdateStatus(Status status)
        {
            _status = status;
        }

        public Status QuestStatus => _status;

        public Marker Marker => _marker;
    }
}