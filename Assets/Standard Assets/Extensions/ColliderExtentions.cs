using Assets.Standard_Assets.Interfaces;
using UnityEngine;

namespace UnityEngine
{
    public static class ColliderExtentions
    {
        public static bool GetIsPlayerCollider(this Collider other)
        {
            if (other.GetComponent<IPlayer>() != null)
            {
                return true;
            }

            return false;
        }

    }
}
