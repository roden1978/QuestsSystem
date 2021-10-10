namespace QuestsSystem
{
    public abstract class Agreement
    {
        private readonly QuestEvent _questEvent;
        private readonly MakerRepositoryProvider _makerRepositoryProvider;

        protected Agreement(QuestEvent questEvent, MakerRepositoryProvider makerRepositoryProvider)
        {
            _questEvent = questEvent;
            _makerRepositoryProvider = makerRepositoryProvider;
        }

        protected abstract bool Condition();

        public void CompleteCondition()
        {
            if (Condition() && _questEvent.QuestStatus != Status.Done)
            {
                _questEvent.UpdateStatus(Status.Done);
                Reward();
            }
        }

        protected abstract void Reward();

        public QuestEvent QuestEvent => _questEvent;

        public MakerRepositoryProvider MakerRepositoryProvider => _makerRepositoryProvider;
    }
}