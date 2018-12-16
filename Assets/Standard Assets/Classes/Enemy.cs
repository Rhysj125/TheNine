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
        public float BaseHealth = 1;
        public float MovementSpeed = 0.02f;
        public GameObject model;
        public NavMeshAgent agent;

        public void FixedUpdate()
        {
            Move();
        }

        public virtual void TakeDamage(float damage)
        {
            Debug.Log("Damage: " + damage);
            BaseHealth -= damage;

            if(BaseHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(model, 0.5f);
        }

        protected virtual void Move()
        {
            //transform.position = Vector3.MoveTowards(model.transform.position, Player.GetInstance().position, MovementSpeed);

            agent.SetDestination(Player.GetInstance().position);
            Debug.Log("Current Destination: " + agent.destination.ToString());
            Debug.Log(transform.position.ToString());
        }
    }
}
