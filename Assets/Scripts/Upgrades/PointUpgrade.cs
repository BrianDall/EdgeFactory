using System;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    public class PointUpgrade : MonoBehaviour
    {
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI CostText;
        public TextMeshProUGUI PointsText;
        
        private PlayerUpgradeData GetUpgradeData()
        {
            return Player.Instance.Upgrades.First(u => u.Name.Equals(NameText.text));
        }

        public void OnAdditiveClick()
        {
            var data = GetUpgradeData();
            if(Player.Instance.CurrentEdges < data.Cost) return;

            Player.Instance.CurrentEdges -= data.Cost;
            data.Cost = (int)(data.Cost * 2);
            Player.Instance.CurrentPointsPerClick++;
            CostText.text = data.Cost.ToString("D");

            var edgesPerClick = Player.Instance.CurrentPointsPerClick / 2;
            PointsText.text = edgesPerClick.ToString(CultureInfo.InvariantCulture);
        }

        public void OnMultiplicativeClick()
        {
            var data = GetUpgradeData();
            if (Player.Instance.CurrentEdges < data.Cost) return;

            Player.Instance.CurrentEdges -= data.Cost;
            data.Cost = (int)Math.Pow(data.Cost, 2);
            Player.Instance.CurrentPointsPerClick *= 2;
            CostText.text = data.Cost.ToString("D");

            var edgesPerClick = Player.Instance.CurrentPointsPerClick / 2;
            PointsText.text = edgesPerClick.ToString(CultureInfo.InvariantCulture);
        }
    }
}
