using Assets.Standard_Assets.Classes;
using Assets.Standard_Assets.Interfaces;
using UnityEngine;

namespace Assets.Standard_Assets.Items
{
    class BaseStatItem : MonoBehaviour
    {
        [SerializeField]
        public BaseStatModifier baseStat;
        public GameObject itemModel;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetIsPlayerCollider())
            {
                if (itemModel != null)
                {
                    baseStat.ApplyStat();
                    Destroy(itemModel);
                }
            }
        }
    }
}
