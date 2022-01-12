namespace RPGSaga.Core
{
    public interface IEffect
    {
        public string EffectTypeName { get; }

        public int Duration { get; set; }

        public int RegularDamage { get; }

        public string Definition { get; }

        public bool SelfEffect { get; }

        public bool SkipFlag { get; }

        public bool UseEffect()
        {
            if (this.Duration > 0)
            {
                Duration--;
                return true;
            }

            return false;
        }
    }
}
