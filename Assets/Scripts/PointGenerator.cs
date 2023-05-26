using UnityEngine;
using UnityEngine.UI;

public class PointGenerator : MonoBehaviour
{
    [SerializeField] private Button PointButton;
    [HideInInspector] private int CurrentPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentPoints = 0;
        PointButton.onClick.AddListener(ClickPoint);
    }

    public void ClickPoint()
    {
        CurrentPoints++;
        if (CurrentPoints < 2) return;

        CurrentPoints = 0;

        var currentEdges = long.Parse(CountEdges.Instance.text);
        currentEdges++;
        CountEdges.Instance.text = currentEdges.ToString("D");
    }
}
