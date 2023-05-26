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

    [HideInInspector] private int Quantity;
    [HideInInspector] private long Cost;

    public void Start()
    {
        //TODO load data
        Quantity = Data != null ? Data.Quantity : 0;
        Cost = Data != null ? Data.Cost : long.MaxValue;
    }

    public void Update()
    {
        if (QuantityText != null) QuantityText.text = Quantity.ToString("D");
        if (CostText != null) CostText.text = Cost.ToString("D");
    }

    public static object BuyLock { get; } = new();

    public void OnBuyClick()
    {
        lock (BuyLock)
        {
            var currentCost = Cost;
            var currentEdges = CountEdges.Instance.CurrentEdges;
            if (currentEdges < currentCost) return;

            //Pay
            CountEdges.Instance.CurrentEdges -= currentCost;
            
            //Increment current quantity
            Quantity++;

            //Increase cost
            Cost *= 2;

            //Increase edges/s
            Data.EdgesPerSecond += Data.Edges;
        }
    }
}
