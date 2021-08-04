using System;

namespace Lavid.Libraske.Avatar
{
    /// <summary> Stores the personalization settings for the avatar </summary>
    [Serializable]
    public struct AvatarStruct<T>
    {
        public T cabelo;
        public T corpo;

        public T iris;
        public T pupila;
        public T olhos;

        public T dentes;
        public T lingua;

        public T camisa;
        public T calca;
        public T acessorios;
    }
}