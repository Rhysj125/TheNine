using Assets.Standard_Assets.Classes;
using UnityEngine;

namespace Assets.Standard_Assets.Items
{
    class ConsumableItem : ItemTrigger
    {
        [SerializeField]
        public VariableStatModifier stat;

        private void OnTriggerEnter(Collider other)
        {
            if (IsValidTriggerEntered(other))
            {
                stat.ApplyStat();
                DestroyItem(this.gameObject);
            }
        }
    }
}
