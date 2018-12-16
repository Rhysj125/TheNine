using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CreateLevelNavMesh : MonoBehaviour {

    //[SerializeField]
    private NavMeshSurface[] surfaces;

    void Start()
    {
        surfaces = GameObject.FindObjectsOfType<NavMeshSurface>();
        //Debug.Log("Nav mesh thing start");
        //Console.WriteLine("can this work please?");
        foreach (NavMeshSurface surface in surfaces)
        {
            surface.BuildNavMesh();
        }
    }

	// Use this for initialization
	void Update () {
        //Debug.Log("Nav mesh thing start");
	}
}
