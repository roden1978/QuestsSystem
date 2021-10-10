namespace QuestsSystem
{
    public class Dragon : Enemy, IQuestMarked
    {
        private GameObject _objectWithMarker;

        public Dragon(GameObject gameObject)
        {
            _objectWithMarker = gameObject;
        }
        public GameObject Die()
        {
            return _objectWithMarker;
        }

    }
}