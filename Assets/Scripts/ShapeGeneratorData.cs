using UnityEngine;

[CreateAssetMenu(fileName = "NewShape", menuName = "New Shape")]
public class ShapeGeneratorData : ScriptableObject
{
    public string Name;
    public string Id;
    public long Cost;
    public Sprite Icon;
    public int Edges;
    [HideInInspector] public int Quantity = 0;
    [HideInInspector] public int EdgesPerSecond = 0;
}
