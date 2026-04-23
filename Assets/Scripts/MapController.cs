/*
Ryer Triezenberg
4/4/2026

 */

using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [Header("=======Misc======")]
    [SerializeField] bool startRoomOpen = false;

    [SerializeField] [Tooltip("The size of a single prefab square's length or width (as they should be the same)")]
     private float roomSize = 1f; //use for room size
    
    [Header("=======Size Variables======")]
    [SerializeField] [Tooltip("Where Player will Begin Maze.")] 
    private Vector3 entrance = new Vector3(); //should assume isn't an exact center
    
    [SerializeField] [Tooltip("Where Player will End Maze.")]    
    private Vector3 exit = new Vector3(); //should assume isn't an exact center
    
    [SerializeField] [Tooltip("Most Negative X, Y and Z corner of the Maze.")]
    private Vector3 mazeBottomLeft = new Vector3(); //corner
    
    [SerializeField] [Tooltip("How many walls to form square.")]
    private int zoneSize; 
    
    //[SerializeField] [Tooltip("Most Positive X, Y and Z corner of the Maze. (This position may not be used precisely to reserve room size)")]
    //private Vector3 mazeTopRight = new Vector3(); //corner

    [Header("=======Object Prefabs======")] //direction currently unclear but I will need TO_ADD Tooltip for direction of doors
    [SerializeField] [Tooltip("Empty Game Object with ZoneController.cs attached")]
    private GameObject[] zones;
    

    /*public class Zone
    {
        int zoneNumber;
        private String zoneString;
        GameObject[] zoneWalls;
        GameObject[] zoneFloors;
        GameObject[] zoneCeilings;
        private Material hideBox
    }*/
    

    public void Start()
    {
        /*if (roomSize.IsUnityNull() || roomSize == 0.0f)
        {
            Debug.Log("Room Size is null!");
            //CalculateObjectSize();
        }*/
        
        BasicRoom();
        
    }
    
    float CalculateObjectSize(GameObject calObject)
    {
        int childNum = calObject.transform.hierarchyCapacity;
        float length = 0;

        for (int i = 0; i < childNum; i++)
        {
            try
            {
                GameObject child = calObject.transform.GetChild(i).gameObject;
                MeshRenderer mRenderer = child.GetComponent<MeshRenderer>();
        
                //Fetch Vector3 of the Mesh for Object
                Vector3 mSize = mRenderer.bounds.size;

                if (mSize.x > mSize.z && mSize.x > length)
                {
                    length = mSize.x;
                } 
                else if(mSize.z > mSize.x && mSize.z > length)
                {
                    length = mSize.z;
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }
        Debug.Log(length);
        return length;
    }
   /* public void CallRooms()
    {
        for (int i = 0; i < roomsZero.Length; i++)
        {
            Vector3 iRoomLocation = new Vector3(roomsZero[i].transform.position.x, roomsZero[i].transform.position.y, roomsZero[i].transform.position.z + (roomSize * i) );
            CreateRoom(roomsZero[i], iRoomLocation);
        }
        
    }*/
    
    public void CallRoomsRand()
    {
        //roomLocation = new Vector3(Random.Range(-15f, 15f), 1f, Random.Range(-10f, 20.0f));
        //CreateRoom(rooms[0], roomLocation);
    }
    

    //Random Vector3
    void CreateRoom(GameObject room, Vector3 roomLocation)
    {
        
        GameObject newRoom =  Instantiate( room, roomLocation, Quaternion.identity );
        //Destroy(newRoom, 5f);
        
    }

    void BasicRoom()
    {
        zones[0].GetComponent<ZoneController>().SpawnZone(mazeBottomLeft, zoneSize);
    }

    void imagineMaze(Vector3 roomLocation, Vector3 exit)
    {
        // Search/build maze
    }
    
}
