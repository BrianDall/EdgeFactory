using UnityEngine;
using UnityEngine.UI;

public class PointGenerator : MonoBehaviour
{
    [SerializeField] private Button PointButton;
    [HideInInspector] private int CurrentPoints;
    [HideInInspector] public int CurrentPointsPerClick;

    public static PointGenerator Instance;

    // Start is called before the first frame update
    void Start()
    {
        //TODO should load this?
        CurrentPointsPerClick = 1;
        CurrentPoints = 0;

        PointButton.onClick.AddListener(ClickPoint);
        Instance = this;
    }

    public void ClickPoint()
    {
        CurrentPoints += CurrentPointsPerClick;
        var edgesGained = CurrentPoints / 2;
        if (edgesGained <= 0) return;

        CurrentPoints %= 2;
        CountEdges.Instance.CurrentEdges += edgesGained;
    }
}
