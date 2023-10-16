using Unity.Entities;

namespace DefaultNamespace
{
    public struct Coins : IComponentData
    {
        public int Amount;
    }
    
    public struct Crystals : IComponentData
    {
        public int Amount;
    }
}