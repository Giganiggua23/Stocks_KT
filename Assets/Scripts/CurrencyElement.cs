using UnityEngine;
using StocksTask.CurrencyLayer;


namespace StocksTask.UILayer
{
    public abstract class CurrencyElement : MonoBehaviour
    {
        protected Currency currency;
        protected MessageDisplayer messageDisplayer;
        public void SetMessageDisplayer(MessageDisplayer displayer)
        {
            messageDisplayer = displayer;
        }

        public virtual void SetCurrency(Currency newCurrency)
        {
            currency = newCurrency;
        }
    }
}
