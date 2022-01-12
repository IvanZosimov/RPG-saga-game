namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class Archer : Player
    {
        public Archer(string name)
            : base(name)
        {
            this.Health = 110;

            this.Power = 40;

            this.PlayerTypeName = "Archer";

            this.PullOfAbilites = new List<IAbility> { new CrossBow(), new FireArrows() };
        }
    }
}
