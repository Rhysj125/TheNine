﻿using System;
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
        public float ActionRate = 3f;
        private float nextAction = 0f;

        //Others
        public GameObject Model;
        public NavMeshAgent Agent;

        private bool IsAttacking;

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
            //Enemy will not move while it is attacking the player
            if (IsAttacking)
            {
                Agent.isStopped = true;
            }else
            {
                Agent.isStopped = false;
                Agent.SetDestination(Player.GetInstance().position);
            }
        }

        private void TryToAttack()
        {
            if (Time.time > nextAction)
            {

                Debug.Log(Vector3.Distance(transform.position, Player.GetInstance().position));

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

        private void Die()
        {
            Destroy(Model, 0.5f);
        }
    }
}