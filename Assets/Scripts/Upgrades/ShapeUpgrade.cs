using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    public class ShapeUpgrade : MonoBehaviour
    {
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI CostText;

        private PlayerUpgradeData GetUpgradeData()
        {
            return Player.Instance.Upgrades.First(u => u.Name.Equals(NameText.text));
        }

        public void OnClick()
        {
            var data = GetUpgradeData();
            if (Player.Instance.CurrentEdges < data.Cost) return;

            Player.Instance.CurrentEdges -= data.Cost;
            data.Cost = (int)(data.Cost * 2);
            Player.Instance.CurrentPointsPerClick++;
            CostText.text = data.Cost.ToString("D");
        }
    }
}
