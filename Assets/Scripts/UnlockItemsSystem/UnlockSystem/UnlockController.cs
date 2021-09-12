using UnityEngine;

namespace Lavid.Libraske.UnlockSystem
{
    [RequireComponent(typeof(UnlockView))]
    public class UnlockController : MonoBehaviour
    {
        [Header("Unlock System MVC")]
        [SerializeField] private UnlockView _view;

        [Header("Money system")]
        [SerializeField] MoneyHandler _moneyHandler;

        private IUnlockable _itemToUnlock;

        public void EnterUnlockRequest(IUnlockable unlockable)
        {
            _itemToUnlock = unlockable;
            _view.EnterUnlockRequest(unlockable.Price, _moneyHandler.GetCurrentMoneyAmount());
        }

        public void SendUnlockRequest()
        {
            if (_itemToUnlock == null || _moneyHandler == null)
                return;

            try
            {
                _moneyHandler.TryUnlockItem(_itemToUnlock);
            }
            catch { }
        }

        public void CloseUnlockRequest(IUnlockable unlockable)
        {
            _view.CloseUnlockRequest(unlockable);
        }
    }
}