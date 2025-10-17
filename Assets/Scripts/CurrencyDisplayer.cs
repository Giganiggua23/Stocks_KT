using UnityEngine;
using TMPro;
using StocksTask.CurrencyLayer;


namespace StocksTask.UILayer
{
    public class CurrencyDisplayer : CurrencyElement
    {
        [SerializeField] private TextMeshProUGUI amountText;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private UnityEngine.UI.Image iconImage;
        void Start()
        {
            if (currency != null)
                Initialize();
        }

        public override void SetCurrency(Currency newCurrency)
        {
            base.SetCurrency(newCurrency);
            Initialize();
        }

        void Initialize()
        {
            nameText.text = currency.currencySO.Name;
            iconImage.sprite = currency.currencySO.Icon;
            currency.OnAmountChanged += UpdateAmount;
        }

        void UpdateAmount(float newAmount)
        {
            amountText.text = newAmount.ToString("F2");
        }

        void OnDestroy()
        {
            if (currency != null)
                currency.OnAmountChanged -= UpdateAmount;
        }
    }
}
