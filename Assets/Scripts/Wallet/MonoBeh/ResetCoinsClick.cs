using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class ResetCoinsClick : MonoBehaviour
    {
        public void Execute()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var signalEntity = entityManager.CreateEntity();
            entityManager.AddComponentData(signalEntity, new ResetCoinsSignal { IsActive = true });
        }
    }
}