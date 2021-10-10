namespace QuestsSystem
{
    public class CollectApplesAgreement : Agreement
    {
        public CollectApplesAgreement(QuestEvent questEvent, MakerRepositoryProvider makerRepositoryProvider) 
            : base(questEvent, makerRepositoryProvider)
        {
        }

        protected override bool Condition()
        {
            throw new System.NotImplementedException();
        }

        protected override void Reward()
        {
            throw new System.NotImplementedException();
        }
    }
}