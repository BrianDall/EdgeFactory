using UnityEngine;

public static class Utils
{
    public static ShapeGeneratorData[] GetAllGenerators()
    {
        return Resources.LoadAll<ShapeGeneratorData>("Shapes");
    }
}
