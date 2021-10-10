using System;
using System.Collections.Generic;

namespace QuestsSystem
{
    public class MarkerRepository
    {
        private readonly List<Type> _markers;

        public MarkerRepository()
        {
            _markers = new List<Type>(10);
        }

        public void AddMarker(Type markerType)
        {
            _markers.Add(markerType);
        }

        public Type[] GetMarkersFromRepository(Type markerType)
        {
            var findMarkers = new List<Type>();
            foreach (var marker in _markers)
            {
                if(marker == markerType)
                    findMarkers.Add(marker);
            }

            return findMarkers.ToArray();
        }
    }
}