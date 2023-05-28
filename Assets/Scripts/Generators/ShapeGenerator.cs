using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Generators
{
    public class ShapeGenerator : MonoBehaviour
    {
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI QuantityText;
        public TextMeshProUGUI CostText;
        public Button BuyButton;

        private PlayerShapeGeneratorData GetGeneratorData()
        {
            return Player.Instance.Generators.First(g => g.Name.Equals(NameText.text));
        }
        
        public void Update()
        {
            var data = GetGeneratorData();
            QuantityText.text = data.Quantity.ToString();
            CostText.text = data.Cost.Format();
        }

        public static object BuyLock { get; } = new();

        public void OnBuyClick()
        {
            lock (BuyLock)
            {
                var data = GetGeneratorData();
                var currentCost = data.Cost;
                var currentEdges = Player.Instance.CurrentEdges;
                if (currentEdges < currentCost) return;

                //Pay
                Player.Instance.CurrentEdges -= currentCost;

                //Increment current quantity
                data.Quantity++;

                //Increase cost
                data.Cost *= 2;
            }
        }
    }
}
