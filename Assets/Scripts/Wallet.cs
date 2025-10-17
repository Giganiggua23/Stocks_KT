using UnityEngine;
using System;
using StocksTask.CurrencyLayer;


namespace StocksTask.WalletLayer
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private CurrencySO neutralCurrencySO;
        [SerializeField] private CurrencySO[] currencySOs;
        public Currency NeutralCurrency { get; private set; }
        public Currency[] Currencies { get; private set; }

        void Start()
        {
            NeutralCurrency = new Currency(neutralCurrencySO);
            Currencies = new Currency[currencySOs.Length];
            for (int i = 0; i < currencySOs.Length; i++)
            {
                Currencies[i] = new Currency(currencySOs[i], NeutralCurrency);
            }
        }

        void Update()
        {
            // Вызываем Tick для обновления стоимости всех торговых валют
            if (Currencies != null)
            {
                for (int i = 0; i < Currencies.Length; i++)
                {
                    Currencies[i].Tick();
                }
            }
        }
    }
}
