using System;

namespace QuestsSystem
{
    public class MakerRepositoryProvider
    {
        private readonly MarkerRepository _markerRepository;
        private readonly Player _player;

        public MakerRepositoryProvider(MarkerRepository markerRepository, Player player)
        {
            _markerRepository = markerRepository;
            _player = player;
        }
        
        public void Subscribe()
        {
            _player.OnMarkedItemTouch += AddMarkerToRepository;
        }

        public void Unsubscribe()
        {
            _player.OnMarkedItemTouch -= AddMarkerToRepository;
        }


        public Type[] GetQuestMarkers(Marker questMarker)
        {
            return _markerRepository.GetMarkersFromRepository(questMarker.GetType());
        }

        public void AddMarkerToRepository(GameObject markedItem)
        {
            _markerRepository.AddMarker(markedItem.Marker.GetType());
        }
    }
}