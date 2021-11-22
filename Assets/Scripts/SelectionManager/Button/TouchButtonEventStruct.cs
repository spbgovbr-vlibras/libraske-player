namespace Lavid.Libraske.Touch
{
    [System.Serializable]
    public struct TouchButtonEventStruct<T>
    {
        public Optional<T> onEnable;
        public Optional<T> onClick;
        public Optional<T> onPointerDown;
        public Optional<T> onEnter;
        public Optional<T> onExit;
    }
}