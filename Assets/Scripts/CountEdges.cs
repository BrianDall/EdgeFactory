using System.Linq;
using TMPro;
using UnityEngine;

public class CountEdges : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CurrentEdgesText;
    private long LastUpdate;
    [HideInInspector] public long CurrentEdges;
    [HideInInspector] public int CurrentEdgesPerSecond;

    public static CountEdges Instance;

    // Start is called before the first frame update
    void Start()
    {
        //TODO should load this data
        CurrentEdgesText.text = "0";
        LastUpdate = Manager.CurrentTime;

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        var currentTime = Manager.CurrentTime;
        var updatesNeeded = currentTime - LastUpdate;
        if (updatesNeeded <= 0) return;
        
        CurrentEdgesPerSecond = Manager.Instance.Generators.Sum(shapeGeneratorData => shapeGeneratorData.EdgesPerSecond);
        var totalEdgesPerSecondGained = CurrentEdgesPerSecond * updatesNeeded;
        CurrentEdges += totalEdgesPerSecondGained;
        LastUpdate = currentTime;
    }

    void LateUpdate()
    {
        CurrentEdgesText.text = CurrentEdges.ToString("D");
    }
}
