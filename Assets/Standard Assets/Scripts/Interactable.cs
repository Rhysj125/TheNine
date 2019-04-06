using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Interactable : MonoBehaviour {

    public float radius = 3f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
