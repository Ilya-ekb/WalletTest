using Unity.Entities;

namespace DefaultNamespace
{
    public class IncrementCoinsSystem : ComponentSystem
    {
        private EntityManager entityManager;

        protected override void OnCreate()
        {
            base.OnCreate();
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        protected override void OnUpdate()
        {
            Entities.ForEach((ref IncrementCoinsSignal incrementSignal) =>
            {
                if (incrementSignal.IsActive)
                {
                    incrementSignal.IsActive = false;
                    Entities.ForEach((ref Coins coins) => coins.Amount++);
                }
            });
            
            entityManager.DestroyEntity(Entities.WithAll<IncrementCoinsSignal>().ToEntityQuery());
        }
    }
}