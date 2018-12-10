using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Standard_Assets.Classes
{
    public abstract class Enemy : MonoBehaviour
    {
        public float BaseHealth = 10;
        public GameObject model;

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
    }
}
