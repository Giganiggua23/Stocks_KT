using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StocksTask.CurrencyLayer;


namespace StocksTask.UILayer
{
    public class CurrencyAggregator : CurrencyElement
    {
        [SerializeField] private TextMeshProUGUI costText;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Button buyButton;
        [SerializeField] private Button sellButton;
        [SerializeField] private Image iconImage;
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
            currency.OnCostChanged += UpdateCost;
            buyButton.onClick.AddListener(OnBuyPressed);
            sellButton.onClick.AddListener(OnSellPressed);
        }

        void UpdateCost(float newCost)
        {
            costText.text = newCost.ToString("F2") + "$";
        }

        void OnBuyPressed()
        {
            if (!currency.TryBuy(1f))
            {
                messageDisplayer.DisplayMessage("Ќевозможно совершить покупку, недостаточно средств");
            }
        }

        void OnSellPressed()
        {
            if (!currency.TrySell(1f))
            {
                messageDisplayer.DisplayMessage("Ќевозможно совершить продажу, недостаточно валюты");
            }
        }

        void OnDestroy()
        {
            if (currency != null)
                currency.OnCostChanged -= UpdateCost;
        }
    }
}