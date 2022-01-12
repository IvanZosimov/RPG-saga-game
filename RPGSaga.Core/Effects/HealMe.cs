namespace RPGSaga.Core
{
    public class HealMe : IEffect
    {
        public string EffectTypeName { get; } = "HealMe";

        public int Duration { get; set; } = 1;

        public int RegularDamage { get; } = -60;

        public string Definition { get; } = "heals by";

        public bool SelfEffect { get; } = true;

        public bool SkipFlag { get; } = false;
    }
}
