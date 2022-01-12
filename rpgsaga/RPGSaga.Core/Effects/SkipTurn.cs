namespace RPGSaga.Core
{
    public class SkipTurn : IEffect
    {
        public string EffectTypeName { get; } = "SkipTurn";

        public int Duration { get; set; } = 1;

        public int RegularDamage { get; } = 0;

        public string Definition { get; } = "skips its turn";

        public bool SelfEffect { get; } = false;

        public bool SkipFlag { get; } = true;
    }
}
