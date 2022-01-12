namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class RegularDamageEntity : Player
    {
        public RegularDamageEntity(string name)
            : base(name)
        {
            this.Health = 200;

            this.Power = 100;

            this.PlayerTypeName = "RegularDamageEntity";

            this.PullOfEffects = new List<IEffect> { new Burning() };
        }
    }
}
