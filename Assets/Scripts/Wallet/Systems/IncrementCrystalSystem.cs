using Unity.Entities;

namespace DefaultNamespace
{
    public class IncrementCrystalSystem : ComponentSystem
    {
        private EntityManager entityManager;

        protected override void OnCreate()
        {
            base.OnCreate();
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        protected override void OnUpdate()
        {
            Entities.ForEach((ref IncrementCrystalSignal incrementSignal) =>
            {
                if (!incrementSignal.IsActive) return;
                incrementSignal.IsActive = false;
                Entities.ForEach((ref Crystals crystals) => crystals.Amount++);
            });
            
            entityManager.DestroyEntity(Entities.WithAll<IncrementCrystalSignal>().ToEntityQuery());
        }
    }
}