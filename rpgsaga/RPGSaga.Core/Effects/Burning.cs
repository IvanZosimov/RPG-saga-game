namespace RPGSaga.Core
{
    public class Burning : IEffect
    {
        public string EffectTypeName { get; } = "Burning";

        public int Duration { get; set; } = 3;

        public int RegularDamage { get; } = 30;

        public string Definition { get; } = "is burning and looses";

        public bool SelfEffect { get; } = false;

        public bool SkipFlag { get; } = false;
    }
}
