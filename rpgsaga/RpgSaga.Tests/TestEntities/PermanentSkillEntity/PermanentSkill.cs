namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class PermanentSkill : IAbility
    {
        public string AbilityTypeName { get; } = "Permanent Skill";

        public int AbilityProbability { get; } = 100;

        public int DamageCoef { get; } = 0;

        public int NumberOfUse { get; set; } = 100;

        public IEnumerable<IEffect> AvailablefEffects { get; set; } = new List<IEffect>() { new SkipTurn() };
    }
}
