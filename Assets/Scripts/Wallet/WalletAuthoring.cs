using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class WalletAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new Coins());
            dstManager.AddComponentData(entity, new Crystals());
        }
    }
}