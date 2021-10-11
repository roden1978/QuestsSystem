using System;

namespace QuestsSystem
{
    public class KillDragonAgreement : Agreement
    {
        private readonly Marker _marker;
        public KillDragonAgreement(Marker marker) 
            : base(marker)
        {
            _marker = marker;
        }

        protected override bool Condition(Marker[] markers)
        {
            foreach (var type in markers)
            {
                if (type.GetType() == _marker.GetType())
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