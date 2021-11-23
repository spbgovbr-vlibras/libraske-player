using System.Collections;
using UnityEngine;

namespace Lavid.Libraske.UnlockSystem
{
    [RequireComponent(typeof(UnlockView))]
    public class UnlockController : MonoBehaviour
    {
        [Header("Unlock System MVC")]
        [SerializeField] private UnlockView _view;

        [Header("Money system")]
        //[SerializeField] MoneyHandler _moneyHandler;
        [SerializeField] RequestUserCredit _requestCredit;
        [SerializeField] UnlockColorSetRequest _unlockColorSetRequest;

        private IUnlockable _itemToUnlock;

        public void CancelRequest()
        {
            _view.CloseUnlockRequest(_itemToUnlock);
        }

        public void EnterUnlockRequest(IUnlockable unlockable)
        {
            _itemToUnlock = unlockable;
            StartCoroutine(EnterUICoroutine(unlockable));
        }

        IEnumerator EnterUICoroutine(IUnlockable unlockable)
        {
            yield return StartCoroutine(_requestCredit.RequestCreditCoroutine());
            _view.EnterUnlockRequest(unlockable.Price, _requestCredit.ReturnCredit());
        }

        public void SendUnlockRequest()
        {
            if (_itemToUnlock == null )
                return;

            _unlockColorSetRequest.TryUnlock(_itemToUnlock);
        }

        public void OnRequestSuccess(IUnlockable item)
        {
            item.Unlock();
            _view.CloseUnlockRequest(item);
        }
    }
}