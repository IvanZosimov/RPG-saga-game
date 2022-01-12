namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class PermanentSkillEntity : Player
    {
        public PermanentSkillEntity(string name)
            : base(name)
        {
            this.Health = 90;

            this.Power = 60;

            this.PlayerTypeName = "PermanentSkillEntity";

            this.PullOfAbilites = new List<IAbility> { new PermanentSkill() };
        }
    }
}
