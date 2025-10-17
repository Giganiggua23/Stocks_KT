using UnityEngine;
using UnityEngine.UI;
using StocksTask.WalletLayer;
using StocksTask.CurrencyLayer;


namespace StocksTask.UILayer
{
    public class CurrencyLayout : MonoBehaviour
    {
        [SerializeField] private Wallet wallet;
        [SerializeField] private MessageDisplayer messageDisplayer;
        [SerializeField] private CurrencyElement elementPrefab;
        [SerializeField] private bool displayNeutralCurrency = true;
        void Start()
        {
            CreateElements();
        }

        void CreateElements()
        {
            if (displayNeutralCurrency)
            {
                CurrencyElement element = Instantiate(elementPrefab, transform);
                element.SetCurrency(wallet.NeutralCurrency);
                element.SetMessageDisplayer(messageDisplayer);
            }

            for (int i = 0; i < wallet.Currencies.Length; i++)
            {
                CurrencyElement element = Instantiate(elementPrefab, transform);
                element.SetCurrency(wallet.Currencies[i]);
                element.SetMessageDisplayer(messageDisplayer);
            }

            UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
        }
    }
}
