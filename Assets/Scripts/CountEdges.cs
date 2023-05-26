using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class CountEdges : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CurrentEdgesText;
    private static long LastUpdate;

    public static TextMeshProUGUI Instance;

    // Start is called before the first frame update
    void Start()
    {
        CurrentEdgesText.text = "0";
        LastUpdate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        Instance = CurrentEdgesText;
    }

    // Update is called once per frame
    void Update()
    {
        var currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        if (currentTime - LastUpdate < 1) return;

        var currentEdges = long.Parse(CurrentEdgesText.text);
        var totalEdgesGainedThisUpdate = Manager.Instance.Generators.Sum(shapeGeneratorData => shapeGeneratorData.EdgesPerSecond);
        var updatedEdges = currentEdges + totalEdgesGainedThisUpdate;
        CurrentEdgesText.text = updatedEdges.ToString("D");
        LastUpdate = currentTime;
    }
}
