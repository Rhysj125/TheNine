using Assets.Standard_Assets.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Standard_Assets.Scripts
{
    class ItemTrigger : MonoBehaviour
    {
        [SerializeField]
        public StatModifier stat;

        private void Start()
        {
            //stat = new StatModifier(Stat.Ammo, 2);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger Entered");

            //if(other.gameObject.tag == "Player")
            //{
            Destroy(this.gameObject);
            stat.ApplyStatBoost();
            //}
        }

    }
}
