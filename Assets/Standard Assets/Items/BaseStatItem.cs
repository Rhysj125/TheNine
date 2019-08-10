using Assets.Standard_Assets.Classes;
using Assets.Standard_Assets.Interfaces;
using Assets.Standard_Assets.Scripts;
using UnityEngine;

namespace Assets.Standard_Assets.Items
{
    class BaseStatItem : Interactable
    {
        [SerializeField]
        public BaseStatModifier baseStat;
        public GameObject itemModel;

        private UI FindUI() => FindObjectOfType<UI>();

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

        private void OnMouseOver()
        {
            if(Vector3.Distance(transform.position, Player.GetInstance().position) <= radius)
            {
                FindUI().DisplayPickUpText();
            }
            else
            {
                FindUI().HidePickUpText();
            }
        }

        private void OnMouseExit() => FindUI().HidePickUpText();
    }
}
