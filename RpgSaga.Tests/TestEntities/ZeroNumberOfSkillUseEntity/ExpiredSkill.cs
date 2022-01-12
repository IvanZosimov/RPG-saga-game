namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class ExpiredSkill : IAbility
    {
        public string AbilityTypeName { get; } = "ExpiredSkill";

        public int AbilityProbability { get; } = 100;

        public int DamageCoef { get; } = 0;

        public int NumberOfUse { get; set; } = 0;

        public IEnumerable<IEffect> AvailablefEffects { get; set; } = new List<IEffect>() { new SkipTurn() };
    }
}
