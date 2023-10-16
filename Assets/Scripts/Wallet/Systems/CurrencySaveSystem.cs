using System;
using System.IO;
using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class CurrencySaveSystem : ComponentSystem
    {
        private EntityManager entityManager;
        private const string saveKey = "CurrencyData";
        protected override void OnCreate()
        {
            base.OnCreate();
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        protected override void OnUpdate()
        {
            Entities.ForEach((ref SaveSignal saveSignal) =>
            {
                if (!saveSignal.IsActive) return;
                saveSignal.IsActive = false;
                Entities.ForEach((ref Coins coins) => { PlayerPrefs.SetInt(saveKey+nameof(Coins), coins.Amount); });

                Entities.ForEach((ref Crystals crystals) => { PlayerPrefs.SetInt(saveKey+nameof(Crystals), crystals.Amount); });

                SaveToFile();
            });
            
            entityManager.DestroyEntity(Entities.WithAll<SaveSignal>().ToEntityQuery());
        }

        private async void SaveToFile()
        {
            var fileName = $"{saveKey}.txt";
            var data = $"{nameof(Coins)}: {GetCoinsAmount()}, {nameof(Crystals)}: {GetCrystalsAmount()}";

            string path = Path.Combine(Application.persistentDataPath, fileName);

            try
            {
                await using (var writer = new StreamWriter(path))
                {
                    await writer.WriteAsync(data);
                }

                Debug.Log("Data saved to file: " + path);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to save data to file: " + e.Message);
            }
        }

        private int GetCoinsAmount()
        {
            var coinsAmount = 0;
            Entities.ForEach((ref Coins coins) => coinsAmount = coins.Amount);
            return coinsAmount;
        }

        private int GetCrystalsAmount()
        {
            var crystalsAmount = 0;
            Entities.ForEach((ref Crystals crystals) => crystalsAmount = crystals.Amount);
            return crystalsAmount;
        }
    }
}