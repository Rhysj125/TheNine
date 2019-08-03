using UnityEngine;

namespace Assets.Standard_Assets.Items
{
    class ConsumableItem : MonoBehaviour
    {
        [SerializeField]
        public VariableStatModifier stat;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetIsPlayerCollider())
            {
                stat.ApplyStat();
                Destroy(this.gameObject);
            }
        }
    }
}
