using Lavid.Libraske.UI;
using UnityEngine;

namespace Lavid.Libraske.UnlockSystem
{
    internal class UnlockView : MonoBehaviour
    {
        [Header("UI Controller")]
        [SerializeField] TextUI _priceText;
        [SerializeField] TextUI _moneyText;
        [SerializeField] GameObject _tooltip;

        [Header("Money system")]
        [SerializeField] GameObject _whenHaveMoney;
        [SerializeField] GameObject _whenDoesntHaveMoney;

        internal void EnterUnlockRequest(int price, int moneyAmount)
        {
            _priceText.SetText(price.ToString());
            _moneyText.SetText(moneyAmount.ToString());

            _whenHaveMoney.SetActive(moneyAmount >= price);
            _whenDoesntHaveMoney.SetActive(!(moneyAmount > price));

            _tooltip.SetActive(true);
        }

        internal void CloseUnlockRequest(IUnlockable unlockable)
        {
            _tooltip.SetActive(false);
        }
    }
}