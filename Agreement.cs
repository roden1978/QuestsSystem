namespace QuestsSystem
{
    public abstract class Agreement
    {
        private readonly Marker _marker;

        protected Agreement(Marker marker)
        {
            _marker = marker;
        }

        protected abstract bool Condition(Marker[] markers);

        public Status CompleteCondition(Status status, Marker[] markers)
        {
            if (Condition(markers) && status != Status.Done)
            {
                Reward();
                return Status.Done;
            }

            return status;
        }

        protected abstract void Reward();
    }
}