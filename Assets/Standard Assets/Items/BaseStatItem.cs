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

        public override void Interact()
        {
            baseStat.ApplyStat();
            Destroy(itemModel);
        }

        private void OnMouseOver()
        {
            var distance = Vector3.Distance(transform.position, Player.GetInstance().position);

            if (distance <= radius && itemModel != null)
            {
                FindUI().DisplayPickUpText();
                Debug.Log("Distance as from BaseStatItem: " + distance);
            }
            else
            {
                FindUI().HidePickUpText();
            }
        }

        private void OnMouseExit() => FindUI().HidePickUpText();
    }
}
