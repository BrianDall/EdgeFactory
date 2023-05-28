using TMPro;
using UnityEngine;

namespace Assets.Scripts.DisplayPanels
{
    public class EdgesDisplayPanel : MonoBehaviour
    {
        public TextMeshProUGUI EdgesCountText;
        public TextMeshProUGUI EdgesPerSecondText;

        public void Update()
        {
            EdgesCountText.text = Player.Instance.CurrentEdges.Format();
            EdgesPerSecondText.text = $"({Player.Instance.GetEdgesPerSecond().Format()}/s)";
        }
    }
}
