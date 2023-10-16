using Unity.Entities;

namespace DefaultNamespace
{
    public class ResetCoinsSystem : ComponentSystem
    {
        private EntityManager entityManager;

        protected override void OnCreate()
        {
            base.OnCreate();
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        protected override void OnUpdate()
        {
            Entities.ForEach((ref ResetCoinsSignal resetSignal) =>
            {
                if (resetSignal.IsActive)
                {
                    resetSignal.IsActive = false;
                    Entities.ForEach((ref Coins coins) => coins.Amount = 0);
                }
            });
            entityManager.DestroyEntity(Entities.WithAll<ResetCoinsSignal>().ToEntityQuery());
        }
    }
}