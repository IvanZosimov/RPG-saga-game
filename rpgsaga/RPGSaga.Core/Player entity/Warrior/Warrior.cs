namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class Warrior : Player
    {
        public Warrior(string name)
            : base(name)
        {
            this.Health = 150;

            this.Power = 30;

            this.PlayerTypeName = "Warrior";

            this.PullOfAbilites = new List<IAbility> { new ColdSight(), new Fury() };
        }
    }
}
