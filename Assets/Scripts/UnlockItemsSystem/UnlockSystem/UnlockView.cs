using Lavid.Libraske.UI;
using UnityEngine;

namespace Lavid.Libraske.UnlockSystem
{
    internal class UnlockView : MonoBehaviour
    {
        [Header("UI Controller")]
        [SerializeField] TextUI _priceText;
        [SerializeField] TextUI _moneyText;
        [SerializeField] GameObject _priceTooltip;
        [SerializeField] GameObject _confirmTooltip;

        [Header("Money system")]
        [SerializeField] GameObject _whenHaveMoney;
        [SerializeField] GameObject _whenDoesntHaveMoney;
		
		private void OnEnable() 
		{	
			_priceTooltip.SetActive(false);
            _confirmTooltip.SetActive(false);
		}

        internal void EnterUnlockRequest(int price, int moneyAmount)
        {
            _priceText.SetText(price.ToString());
            _moneyText.SetText(moneyAmount.ToString());

            _whenHaveMoney.SetActive(moneyAmount >= price);
            _whenDoesntHaveMoney.SetActive(!(moneyAmount > price));

            _priceTooltip.SetActive(true);
        }

        internal void CloseUnlockRequest(IUnlockable unlockable)
        {
            _priceTooltip.SetActive(false);
            _confirmTooltip.SetActive(false);
        }
    }
}