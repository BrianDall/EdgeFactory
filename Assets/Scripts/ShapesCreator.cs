using System.Collections;
using UnityEngine;

public class ShapesCreator : MonoBehaviour
{
    [SerializeField] private GameObject shapeGeneratorPrefab;
    [SerializeField] private Transform container;

    private void Start()
    {
        StartCoroutine(CreateShapes());
    }

    IEnumerator CreateShapes()
    {
        yield return new WaitForEndOfFrame();

        foreach (var generatorData in Manager.Instance.Generators)
        {
            generatorData.Quantity = 0;
            generatorData.EdgesPerSecond = 0;
            GameObject instance = Instantiate(shapeGeneratorPrefab, container);
            instance.name = generatorData.Name;
            ShapeGenerator shapeGenerator = instance.GetComponent<ShapeGenerator>();
            shapeGenerator.Data = generatorData;

            shapeGenerator.Icon.sprite = generatorData.Icon;
            shapeGenerator.NameText.text = generatorData.Name;
            shapeGenerator.QuantityText.text = generatorData.Quantity.ToString("D");
            shapeGenerator.CostText.text = generatorData.Cost.ToString("D");
            shapeGenerator.BuyButton.onClick.AddListener(() => shapeGenerator.OnBuyClick());
        }
    }
}
