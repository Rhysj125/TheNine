using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public float AttackRate = 3f;
        private float nextAttack = 0f;

        //Others
        public GameObject Model;
        public NavMeshAgent Agent;

        public void FixedUpdate()
        {
            Move();
            TryToAttack();
        }

        public virtual void TakeDamage(float damage)
        {
            BaseHealth -= damage;

            if(BaseHealth <= 0)
            {
                Die();
            }
        }

        protected virtual void Move()
        {
            //transform.position = Vector3.MoveTowards(model.transform.position, Player.GetInstance().position, MovementSpeed);

            Agent.SetDestination(Player.GetInstance().position);
        }

        private void TryToAttack()
        {
            if (Time.time > nextAttack)
            {

                Debug.Log(Vector3.Distance(transform.position, Player.GetInstance().position));

                nextAttack = Time.time + 1 / AttackRate;

                if (Math.Abs(Vector3.Distance(transform.position, Player.GetInstance().position)) <= AttackRange)
                {
                    Debug.Log("Attacking");
                    Player.GetInstance().TakeDamage(Damage);
                }
            }
        }

        private void Die()
        {
            Destroy(Model, 0.5f);
        }
    }
}
