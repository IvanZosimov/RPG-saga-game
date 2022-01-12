namespace RPGSaga.Core
{
    public class NoSkillEntity : Player
    {
        public NoSkillEntity(string name)
            : base(name)
        {
            this.Health = 100;

            this.Power = 100;

            this.PlayerTypeName = "NoSkillEntity";
        }
    }
}
