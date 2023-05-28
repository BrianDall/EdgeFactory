using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public static Player Instance;

        public Player()
        {
            Id = Guid.NewGuid();
            Name = "New Player";
            LastUpdate = Utilities.GetCurrentTime();
            CurrentEdges = 10;
            CurrentPointsPerClick = 1;
            CurrentPoints = 0;
            Generators = new[]
            {
                new PlayerShapeGeneratorData
                {
                    Name = "Triangle",
                    Quantity = 0,
                    Cost = 30,
                    EdgesPerSecond = 3
                },
                new PlayerShapeGeneratorData
                {
                    Name = "Square",
                    Quantity = 0,
                    Cost = 40,
                    EdgesPerSecond = 4
                },
                new PlayerShapeGeneratorData
                {
                    Name = "Pentagon",
                    Quantity = 0,
                    Cost = 50,
                    EdgesPerSecond = 5
                },
                new PlayerShapeGeneratorData
                {
                    Name = "Hexagon",
                    Quantity = 0,
                    Cost = 60,
                    EdgesPerSecond = 6
                }
            };
            Upgrades = new[]
            {
                new PlayerUpgradeData
                {
                    Name = "Point +",
                    Cost = 10
                },
                new PlayerUpgradeData
                {
                    Name = "Point *",
                    Cost = 100
                }
            };
        }

        public void Awake()
        {
            Instance = this;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public long LastUpdate { get; set; }
        public long CurrentEdges { get; set; }

        public double CurrentPointsPerClick { get; set; }
        public double CurrentPoints { get; set; }

        public PlayerShapeGeneratorData[] Generators { get; set; }
        public PlayerUpgradeData[] Upgrades { get; set; }

        public long GetEdgesPerSecond()
        {
            return Generators.Sum(g => g.EdgesPerSecond * g.Quantity);
        }

        public void Update()
        {
            var currentTime = Utilities.GetCurrentTime();
            var updatesNeeded = currentTime - LastUpdate;
            if (updatesNeeded <= 0) return;

            var totalEdgesPerSecondGained = GetEdgesPerSecond() * updatesNeeded;
            CurrentEdges += totalEdgesPerSecondGained;
            LastUpdate = currentTime;
        }
    }
    
    public class PlayerShapeGeneratorData
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public long Cost { get; set; }
        public long EdgesPerSecond { get; set; }
    }

    public class PlayerUpgradeData
    {
        public string Name { get; set; }
        public long Cost { get; set; }
    }
}
