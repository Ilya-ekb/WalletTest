using Unity.Entities;

namespace DefaultNamespace
{
    public struct IncrementCoinsSignal : IComponentData
    {
        public bool IsActive;
    }

    public struct ResetCoinsSignal : IComponentData
    {
        public bool IsActive;
    }
}