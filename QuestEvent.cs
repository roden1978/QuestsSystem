namespace QuestsSystem
{
    public abstract class QuestEvent
    {
        protected QuestEvent()
        {
            QuestStatus = Status.Waiting;
        }
        
        public void UpdateStatus(Status status)
        {
            QuestStatus = status;
        }

        public Status QuestStatus { get; private set; }

    }
}