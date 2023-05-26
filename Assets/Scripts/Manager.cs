using System;
using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }

    public ShapeGeneratorData[] Generators;

    private void Awake()
    {
        Instance = this;

        Generators = Utils.GetAllGenerators().OrderBy(g => g.Id).ToArray();
    }

    public static long CurrentTime => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
}
