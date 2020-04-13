using Assets.Standard_Assets.Classes;
using Assets.Standard_Assets.Enums;
using Assets.Standard_Assets.Interfaces;
using System.Linq;
using UnityEngine;

namespace Assets.Standard_Assets.Enemies
{
    class ExplosiveEnemy : Enemy, IExplosive
    {
        public float ExplosiveRadius => 10f;
        public int ExplosiveDamage => 10;

        public bool IsExploding { get; set; }

        public const float DetonationRange = 2;

        protected override void Move()
        {
            if (agent.isOnNavMesh)
            {
                //Enemy will not move while it is attacking the player
                if (IsAttacking)
                {
                    agent.isStopped = true;
                }
                else
                {
                    agent.isStopped = false;
                    agent.SetDestination(Player.GetInstance().position);
                }
            }
            else
            {
                this.Die();
            }
        }

        protected override void Die(bool isPlayerKill = false)
        {
            base.Die(isPlayerKill);
            if (!IsExploding)
            {
                Explode();
            }
        }

        public void Explode()
        {
            Destory();
            IsExploding = true;

            var colliders = Physics
                .OverlapSphere(transform.position, ExplosiveRadius);

            var damagables = colliders
                .Select(c => c.GetComponent<IDamageable>())
                .Where(d => d != null)
                .ToArray();

            foreach (var damagable in damagables)
            {
                damagable?.TakeDamage(ExplosiveDamage, DamageType.Explosive);
            }
        }
    }
}
