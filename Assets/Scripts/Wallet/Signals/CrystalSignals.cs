using Unity.Entities;

namespace DefaultNamespace
{
    public struct IncrementCrystalSignal : IComponentData
    {
        public bool IsActive;
    }

    public struct ResetCrystalsSignal : IComponentData
    {
        public bool IsActive;
    }
}