using System.Net.Mime;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CurrencyDisplaySystem : ComponentSystem
    {
        private Text coinsView;
        private Text crystalsView;

        protected override void OnCreate()
        {
            base.OnCreate();
            coinsView = GameObject.Find(nameof(Coins)).GetComponent<Text>();
            crystalsView = GameObject.Find(nameof(Crystals)).GetComponent<Text>();
        }

        protected override void OnUpdate()
        {
            Entities.ForEach((ref Coins coins) =>
            {
                if (coinsView)
                    coinsView.text = $"{nameof(Coins)}: {coins.Amount}";
            });

            Entities.ForEach((ref Crystals crystals) =>
            {
                if (crystalsView)
                    crystalsView.text = $"{nameof(Crystals)}: {crystals.Amount}";
            });
        }
    }
}