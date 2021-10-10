using System;

namespace QuestsSystem
{
    public class KillDragonAgreement : Agreement
    {
        public KillDragonAgreement(QuestEvent questEvent, MakerRepositoryProvider makerRepositoryProvider) 
            : base(questEvent, makerRepositoryProvider)
        {
        }

        protected override bool Condition()
        {
            var markers = MakerRepositoryProvider.GetQuestMarkers(QuestEvent.Marker);
            foreach (var type in markers)
            {
                if (type == QuestEvent.Marker.GetType())
                {
                    return true;
                }
            }
            return false;
        }

        protected override void Reward()
        {
            Console.WriteLine(" 100 Gold for kill dragon");
        }
    }
}