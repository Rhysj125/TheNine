using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Standard_Assets.Classes
{
    public abstract class Enemy : MonoBehaviour
    {
        //Movement properties
        public float BaseHealth = 1;
        public float MovementSpeed = 0.02f;

        //Attacking properties
        public int Damage = 10;
        public float AttackRange = 3f;
        public float ActionRate = 3f;
        private float nextAction = 0f;

        //Others
        public GameObject Model;
        protected NavMeshAgent agent;

        // Enemy State
        protected bool IsAttacking;

        protected void Start()
        {
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
            
            Level.GetInstance().IncrementEnemyCount();
        }

        public virtual void TakeDamage(float damage)
        {
            BaseHealth -= damage;

            if(BaseHealth <= 0)
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
                    Player.GetInstance().TakeDamage(Damage);
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

            Level.GetInstance().DecrementEnemyCount();

            Destroy(Model);

            if (isPlayerKill)
            {
                GameObject drop = Instantiate(ResourceLoader.GetItems()[0], currentPosition, Quaternion.identity);

                currentPosition.y = new System.Random().Next(10);
                currentPosition.x = new System.Random().Next(10);
                currentPosition.z = new System.Random().Next(10);

                drop.GetComponent<Rigidbody>().AddForce(new Vector3(new System.Random().Next(5), new System.Random().Next(5), new System.Random().Next(5)), ForceMode.VelocityChange);
            }
        }
    }
}
