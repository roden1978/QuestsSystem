namespace QuestsSystem
{
    public class CollectApplesAgreement : Agreement
    {
        public CollectApplesAgreement(Marker marker) 
            : base(marker)
        {
        }


        protected override bool Condition(Marker[] markers)
        {
            throw new System.NotImplementedException();
        }

        protected override void Reward()
        {
            throw new System.NotImplementedException();
        }
    }
}