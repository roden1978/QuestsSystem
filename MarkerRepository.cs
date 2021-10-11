using System.Collections.Generic;

namespace QuestsSystem
{
    public class MarkerRepository
    {
        private readonly List<Marker> _markers;

        public MarkerRepository()
        {
            _markers = new List<Marker>(10);
        }

        public void AddMarker(Marker marker)
        {
            _markers.Add(marker);
        }

        public Marker[] GetMarkersFromRepository(Marker marker)
        {
            var findMarkers = new List<Marker>();
            foreach (var item in _markers)
            {
                if (item.GetType() == marker.GetType()) 
                    findMarkers.Add(marker);
            }

            return findMarkers.ToArray();
        }

        public Marker[] GetAllMarkers()
        {
            return _markers.ToArray();
        }
    }
}