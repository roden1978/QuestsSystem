namespace QuestsSystem
{
    public class FindPrincessAgreement : Agreement
    {
        public FindPrincessAgreement(QuestEvent questEvent, MakerRepositoryProvider makerRepositoryProvider) 
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