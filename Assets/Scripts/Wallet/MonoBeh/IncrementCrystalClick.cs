using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class IncrementCrystalClick : MonoBehaviour
    {
        public void Execute()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var signalEntity = entityManager.CreateEntity();
            entityManager.AddComponentData(signalEntity, new IncrementCrystalSignal { IsActive = true });
        }
    }
}