using UnityEngine.EventSystems;

namespace Lavid.Libraske.Touch
{
    public interface ITouchComponent : IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler { }
}