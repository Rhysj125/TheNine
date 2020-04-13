using Assets.Standard_Assets.Enums;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Standard_Assets.Classes
{
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        protected virtual int DropChance => 75;

        // Health
        public virtual int BaseHealth => 1;
        private float remainingHealth;

        // Movement
        protected virtual float MovementSpeed => 0.02f;

        // Attack
        protected virtual int Damage => 10;
        protected virtual float AttackRange => 3f;
        protected virtual float ActionRate => 3f;

        private float nextAction = 0f;

        // Others
        public GameObject Model;
        protected NavMeshAgent agent;

        // Enemy State
        protected bool IsAttacking;

        protected void Start()
        {
            remainingHealth = BaseHealth;
            agent = Model.GetComponent<NavMeshAgent>();
        }

        protected virtual void FixedUpdate()
        {
            Move();
            TryToAttack();
        }

        public virtual void Spawn(GameObject gameObject, Vector3 position, Quaternion rotation)
        {
            Instantiate(gameObject, position, rotation);
            
            Level.IncrementEnemyCount();
        }

        public virtual void TakeDamage(int damage, DamageType damageType)
        {
            remainingHealth -= damage;

            if(remainingHealth <= 0)
            {
                Die(true);
            }
        }

        protected virtual void Move()
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

        protected virtual void TryToAttack()
        {
            // Ensuring the enemy doesn't attack every update.
            if (Time.time > nextAction)
            {
                nextAction = Time.time + 1 / ActionRate;

                if (Math.Abs(Vector3.Distance(transform.position, Player.GetInstance().position)) <= AttackRange)
                {
                    IsAttacking = true;
                    Player.GetInstance().TakeDamage(Damage, DamageType.Melee);
                }
                else
                {
                    IsAttacking = false;
                }
            }
        }

        protected virtual void Die(bool isPlayerKill = false)
        {
            Vector3 currentPosition = Model.transform.position;

            Level.DecrementEnemyCount();

            Destroy(Model);

            int randomChance = UnityEngine.Random.Range(0, 100);

            if (isPlayerKill)
            {
                if (randomChance >= DropChance)
                {
                    GameObject drop = Instantiate(ResourceLoader.GetItems()[0], currentPosition, Quaternion.identity);

                    currentPosition.y = new System.Random().Next(10);
                    currentPosition.x = new System.Random().Next(10);
                    currentPosition.z = new System.Random().Next(10);

                    drop.GetComponent<Rigidbody>().AddForce(new Vector3(new System.Random().Next(5), new System.Random().Next(5), new System.Random().Next(5)), ForceMode.VelocityChange);
                }
            }
        }

        public void TakeDamage(int damage)
        {
            throw new NotImplementedException();
        }

        public void Destory()
        {
            throw new NotImplementedException();
        }
    }
}
