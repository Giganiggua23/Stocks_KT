using UnityEngine;
using StocksTask.NumericsLayer;


namespace StocksTask.CurrencyLayer
{
    [CreateAssetMenu(fileName = "CurrencySO", menuName = "SO/Currency", order = 51)]
    public class CurrencySO : ScriptableObject
    {
        [SerializeField] private string nameField;
        [SerializeField] private Range costRange;
        [SerializeField] private Sprite icon;
        [SerializeField, Range(0f, 1f)] private float changeCoefficient = 0.5f;
        [SerializeField] private float costUpdateDelay = 5f;
        [SerializeField] private float initialAmount = 10f;
        public string Name => nameField;
        public Range CostRange => costRange;
        public Sprite Icon => icon;
        public float ChangeCoefficient => changeCoefficient;
        public float CostUpdateDelay => costUpdateDelay;
        public float InitialAmount => initialAmount;
    }
}