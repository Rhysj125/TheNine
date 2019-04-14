using Assets.Standard_Assets.Classes;
using UnityEngine;

namespace Assets.Standard_Assets.Items
{
    class BaseStatItem : ItemTrigger
    {
        [SerializeField]
        public BaseStatModifier baseStat;

        private void OnTriggerEnter(Collider other)
        {
            if (IsValidTriggerEntered(other))
            {
                baseStat.ApplyStat();
                DestroyItem(this.GetComponentInParent<GameObject>());
            }
        }
    }
}
