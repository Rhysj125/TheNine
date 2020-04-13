using Assets.Standard_Assets.Classes;
using Assets.Standard_Assets.Enums;
using System;

namespace Assets.Standard_Assets.Scripts
{
    class RangedEnemy : Enemy
    {
        public override void TakeDamage(int damage, DamageType damageType)
        {
            base.TakeDamage(Convert.ToInt32(Math.Floor(damage * 1.5f)));
        }
    }
}
