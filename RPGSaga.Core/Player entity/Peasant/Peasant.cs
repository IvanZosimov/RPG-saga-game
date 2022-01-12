namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class Peasant : Player
    {
        public Peasant(string name)
            : base(name)
        {
            this.Health = 10;

            this.PlayerTypeName = "Peasant";
        }

        protected internal override IReadOnlyList<IAbility> PullOfAbilites
        {
            get
            {
                throw new PlayerException(this.PlayerTypeName);
            }
        }
    }
}
