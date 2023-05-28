using System.Globalization;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Generators
{
    public class PointGenerator : MonoBehaviour
    {
        public void OnClickPoint()
        {
            Player.Instance.CurrentPoints += Player.Instance.CurrentPointsPerClick;
            var edgesGained = (int)Player.Instance.CurrentPoints / 2;
            if (edgesGained <= 0) return;

            Player.Instance.CurrentPoints %= 2;
            Player.Instance.CurrentEdges += edgesGained;
        }
    }
}
