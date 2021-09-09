using System;

namespace Lavid.Libraske.UnlockSystem
{
    public class NotEnoughMoneyException : Exception 
    {
        public override string Message => "Your money is not enought";
    }
}