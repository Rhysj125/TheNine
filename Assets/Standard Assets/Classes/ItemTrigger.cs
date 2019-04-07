using UnityEngine;

namespace Assets.Standard_Assets.Classes
{
    public abstract class ItemTrigger : MonoBehaviour
    {
        protected bool IsValidTriggerEntered(Collider other)
        {
            if (other.GetComponent<Rigidbody>().tag == "Player")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual void DestroyItem(GameObject item)
        {
            Destroy(item);
        }
    }
}
