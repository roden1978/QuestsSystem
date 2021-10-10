namespace QuestsSystem
{
    public class GameObject : IMarkerGiver
    {
        protected GameObject(Marker marker)
        {
            Marker = marker;
        }
        public Marker Marker { get; }
    }
}