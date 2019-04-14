using System;
using Assets.Standard_Assets.Classes;
using UnityEngine;

namespace Assets.Standard_Assets.Scripts
{
    class MeleeEnemy : Enemy
    {
        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage * 0.5f);
        }
    }
}
