namespace QuestsSystem
{
    public class DragonTooth : GameObject
    {
        public DragonTooth(Marker marker) : base(marker)
        {
            Marker = marker;
        }
        
        public Marker Marker { get; }
        
    }
}