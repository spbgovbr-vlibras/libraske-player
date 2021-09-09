using UnityEngine;

namespace Lavid.Libraske.UnlockSystem
{
    public class MoneyHandler : MonoBehaviour
    {
        [SerializeField] private int _money;

        public void TryUnlockItem(IUnlockable item)
        {
            _money = GetCurrentMoneyAmount();

            if (item.Price > _money)
                throw new NotEnoughMoneyException();
            else
            {
                item.Unlock();
                SetCurrentMoneyAmount(_money - item.Price);
            }
        }
        
        // TODO: Set on web
        public void SetCurrentMoneyAmount(int value)
        {
            _money = value;
        }

        // TODO: Get on web
        public int GetCurrentMoneyAmount()
        {
            return _money;
        }
    }
}