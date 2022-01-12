namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class Mage : Player
    {
        public Mage(string name)
            : base(name)
        {
            this.Health = 90;

            this.Power = 60;

            this.PlayerTypeName = "Mage";

            this.PullOfAbilites = new List<IAbility> { new HoldOn(), new FullResist() };
        }
    }
}
