using Assets.Standard_Assets.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Standard_Assets.Enemies
{
    class ExplosiveEnemy : Enemy
    {
        public readonly float EXPLOSION_RANGE = 10;
        public readonly float DETONATION_RANGE = 2;

        public float ExplosionDamage;

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

            float distanceBetweenEnemyAndPlayer = Vector3.Distance(this.transform.position, Player.GetInstance().position);

            if (distanceBetweenEnemyAndPlayer <= EXPLOSION_RANGE)
            {
                Player.GetInstance().TakeExplosiveDamage((int) ExplosionDamage);
            }
        }
    }
}
