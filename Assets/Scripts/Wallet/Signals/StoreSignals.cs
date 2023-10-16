using Unity.Entities;

namespace DefaultNamespace
{
    public struct SaveSignal : IComponentData
    {
        public bool IsActive;
    }

    public struct LoadSignal : IComponentData
    {
        public bool IsActive;
    }
}