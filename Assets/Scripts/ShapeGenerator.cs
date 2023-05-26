using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShapeGenerator : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public Button BuyButton;
    public Image Icon;
    public TextMeshProUGUI QuantityText;
    public TextMeshProUGUI CostText;
    [HideInInspector] public ShapeGeneratorData Data;

    public static object BuyLock { get; } = new();

    public void OnBuyClick()
    {
        lock (BuyLock)
        {
            var currentCost = long.Parse(CostText.text);
            var currentEdges = long.Parse(CountEdges.Instance.text);
            if (currentEdges < currentCost) return;

            //Pay
            var updatedEdges = currentEdges - currentCost;
            CountEdges.Instance.text = updatedEdges.ToString("D");

            //Increment current quantity
            var currentQuantity = long.Parse(QuantityText.text);
            currentQuantity++;
            QuantityText.text = currentQuantity.ToString("D");

            //Increase cost
            currentCost *= 2;
            CostText.text = currentCost.ToString("D");

            //Increase edges/s
            Data.EdgesPerSecond += Data.Edges;
        }
    }
}
