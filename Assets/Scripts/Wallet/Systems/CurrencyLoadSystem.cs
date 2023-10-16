using System;
using System.IO;
using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class CurrencyLoadSystem : ComponentSystem
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
            Entities.ForEach((ref LoadSignal loadSignal) =>
            {
                if(!loadSignal.IsActive) return;
                Entities.ForEach((ref Coins coins) => { coins.Amount = PlayerPrefs.GetInt(saveKey + nameof(Coins)); });

                Entities.ForEach((ref Crystals crystals) =>
                {
                    crystals.Amount = PlayerPrefs.GetInt(saveKey + nameof(Crystals));
                });
                LoadFromFile();
            });
            
            entityManager.DestroyEntity(Entities.WithAll<LoadSignal>().ToEntityQuery());
        }

        private async void LoadFromFile()
        {
            string fileName = $"{saveKey}.txt";
            string path = Path.Combine(Application.persistentDataPath, fileName);

            try
            {
                using var reader = new StreamReader(path);
                var data = await reader.ReadToEndAsync();
                Debug.Log("Data loaded from file: " + data);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to load data from file: " + e.Message);
            }
        }
    }
}