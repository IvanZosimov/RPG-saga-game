namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class SkipTurnEntity : Player
    {
        public SkipTurnEntity(string name)
            : base(name)
        {
            this.Health = 200;

            this.Power = 100;

            this.PlayerTypeName = "SkipTurnEntity";

            this.PullOfEffects = new List<IEffect> { new SkipTurn() };
        }
    }
}
