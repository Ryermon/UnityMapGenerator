/*
Ryer Triezenberg
4/4/2026

 */

using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [SerializeField] private Vector3 roomLocation = new Vector3();

    [SerializeField] private GameObject[] rooms;
    
    //use for room size
    [SerializeField] private float roomUnit = 1f;

    public void CallRooms()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            Vector3 iRoomLocation = new Vector3(rooms[i].transform.position.x, rooms[i].transform.position.y, rooms[i].transform.position.z + (roomUnit * i) );
            CreateRoom(rooms[i], iRoomLocation);
        }
        
    }
    
    public void CallRoomsRand()
    {
        roomLocation = new Vector3(Random.Range(-15f, 15f), 1f, Random.Range(-10f, 20.0f));
        CreateRoom(rooms[0], roomLocation);
    }
    

    //Random Vector3
    void CreateRoom(GameObject room, Vector3 roomLocation)
    {
        
        GameObject newRoom =  Instantiate( room, roomLocation, Quaternion.identity );
        //Destroy(newRoom, 5f);
        
    }
    
}
