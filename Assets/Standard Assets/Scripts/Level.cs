using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    public GameObject room;
    private List<GameObject> rooms = new List<GameObject>();
    private int roomID = 0;

	// Use this for initialization
	void Start () {
        rooms.Add(room);
        rooms.Add(room);
        rooms.Add(room);

        foreach (GameObject currentRoom in rooms)
        {
            currentRoom.SetActive(false);
            GameObject obj = (GameObject) Instantiate(currentRoom, new Vector3(0, 0, 0), Quaternion.identity);
            obj.transform.parent = transform;
        }
	}
	
    public void GoForward()
    {
        if (rooms.Count < roomID)
        {
            rooms[roomID].SetActive(false);
            roomID++;
            rooms[roomID].SetActive(true);
        }
    }

    public void GoBackward()
    {
        if (roomID < 0) { 
            rooms[roomID].SetActive(false);
            roomID--;
            rooms[roomID].SetActive(true);
        }
    }
}
