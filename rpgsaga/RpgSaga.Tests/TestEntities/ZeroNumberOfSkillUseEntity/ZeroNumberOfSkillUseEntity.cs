namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class ZeroNumberOfSkillUseEntity : Player
    {
        public ZeroNumberOfSkillUseEntity(string name)
            : base(name)
        {
            this.Health = 90;

            this.Power = 60;

            this.PlayerTypeName = "ZeroNumberOfSkillUseEntity";

            this.PullOfAbilites = new List<IAbility> { new ExpiredSkill() };
        }
    }
}
