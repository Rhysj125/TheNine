using Assets.Standard_Assets.Enums;
using Assets.Standard_Assets.Interfaces;
using System.Linq;
using UnityEngine;

namespace Assets.Standard_Assets.Scripts
{
    public class Barrel : MonoBehaviour, IExplosive, IDamageable
    {
        public float ExplosiveRadius => 5f;
        public int ExplosiveDamage => 100;
        public int BaseHealth => 0;

        public bool IsExploding { get; set; }

        public GameObject Model;
        

        public void Destory()
        {
            Destroy(Model);
        }

        public void Explode()
        {
            Destory();
            IsExploding = true;

            var colliders = Physics
                .OverlapSphere(transform.position, ExplosiveRadius);

            var damagables = colliders
                .Select(c => c.GetComponent<IDamageable>())
                .Where(d => d != null)
                .ToArray();

            foreach(var damagable in damagables)
            {
                damagable?.TakeDamage(ExplosiveDamage, DamageType.Explosive);
            }
        }

        public void TakeDamage(int damage, DamageType damageType)
        {
            if (!IsExploding)
            {
                switch(damageType)
                {
                    case DamageType.Explosive:
                    case DamageType.Bullet:
                        Explode();
                        break;

                    default:
                        break;
                }
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, ExplosiveRadius);
        }
    }
}