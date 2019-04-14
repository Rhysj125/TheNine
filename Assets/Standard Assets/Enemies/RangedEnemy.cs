using System;
using Assets.Standard_Assets.Classes;
using UnityEngine;

namespace Assets.Standard_Assets.Scripts
{
    class RangedEnemy : Enemy
    {
        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage * 1.5f);
        }
    }
}
