namespace RPGSaga.Core
{
    using System;

    public class PlayerException : Exception
    {
        public PlayerException(string typeOfPlayer)
        {
            this.TypeOfPlayer = typeOfPlayer;
        }

        public string TypeOfPlayer { get; }
    }
}
