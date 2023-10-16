using Unity.Entities;

namespace DefaultNamespace
{
    public class ResetCrystalSystem : ComponentSystem
    {
        private EntityManager entityManager;

        protected override void OnCreate()
        {
            base.OnCreate();
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        protected override void OnUpdate()
        {
            Entities.ForEach((ref ResetCrystalsSignal resetSignal) =>
            {
                if (!resetSignal.IsActive) return;
                resetSignal.IsActive = false;
                Entities.ForEach((ref Crystals crystals) => crystals.Amount = 0);
            });
            entityManager.DestroyEntity(Entities.WithAll<ResetCrystalsSignal>().ToEntityQuery());
        }
    }
}