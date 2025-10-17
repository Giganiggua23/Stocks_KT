using UnityEngine;
using System;


namespace StocksTask.CurrencyLayer
{
    public class Currency
    {
        public readonly CurrencySO currencySO;
        public float Amount { get; private set; }
        public float Cost { get; private set; }
        public event Action<float> OnAmountChanged;
        public event Action<float> OnCostChanged;

        private readonly Currency neutralCurrency;
        private float timeUntilRefresh;

        public Currency(CurrencySO currencySO)
        {
            this.currencySO = currencySO;
            Amount = currencySO.InitialAmount;
            Cost = (currencySO.CostRange.min + currencySO.CostRange.max) * 0.5f;
            timeUntilRefresh = currencySO.CostUpdateDelay;
            OnAmountChanged?.Invoke(Amount);
            OnCostChanged?.Invoke(Cost);
        }

        // ƒл€ торговых валют (требуетс€ нейтральна€ валюта дл€ покупок/продаж)
        public Currency(CurrencySO currencySO, Currency neutralCurrency) : this(currencySO)
        {
            this.neutralCurrency = neutralCurrency;
        }

        // ќбновление стоимости через указанный интервал, вызываетс€ в Update кошелька
        public void Tick()
        {
            timeUntilRefresh -= Time.deltaTime;
            if (timeUntilRefresh <= 0f)
            {
                RefreshCost();
                timeUntilRefresh = currencySO.CostUpdateDelay;
            }
        }

        public bool TryBuy(float amountToBuy)
        {
            // —тоимость покупки = цена * количество, списываетс€ из нейтральной валюты
            float totalCost = amountToBuy * Cost;
            if (neutralCurrency == null || neutralCurrency.Amount < totalCost)
                return false;
            neutralCurrency.DecreaseAmount(totalCost);
            IncreaseAmount(amountToBuy);
            return true;
        }

        public bool TrySell(float amountToSell)
        {
            if (Amount < amountToSell)
                return false;
            DecreaseAmount(amountToSell);
            if (neutralCurrency != null)
                neutralCurrency.IncreaseAmount(amountToSell * Cost);
            return true;
        }

        void IncreaseAmount(float delta)
        {
            Amount += delta;
            OnAmountChanged?.Invoke(Amount);
        }

        void DecreaseAmount(float delta)
        {
            Amount -= delta;
            OnAmountChanged?.Invoke(Amount);
        }

        void RefreshCost()
        {
            float rndPrice = UnityEngine.Random.Range(currencySO.CostRange.min, currencySO.CostRange.max);
            float diff = rndPrice - Cost;
            Cost += diff * currencySO.ChangeCoefficient;
            OnCostChanged?.Invoke(Cost);
        }
    }
}
