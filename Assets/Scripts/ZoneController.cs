using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class ZoneController : MonoBehaviour
{
    //int zoneNumber;
    //private String zoneString;
    [SerializeField] GameObject[] zoneRooms;
    //GameObject[] zoneFloors;
    //GameObject[] zoneCeilings;
    [SerializeField] private Material hideBox;
    [SerializeField] private static int numberOfWalls = 0;
    [SerializeField] float wallLength;
    [SerializeField] float wallHeight;
  

    
    
    Dictionary<Vector3, GameObject> zoneDictionary = new Dictionary<Vector3, GameObject>();
    Dictionary<string, GameObject> testDictionary = new Dictionary<string, GameObject>();
    //allObjects.Add(Vector3(2,10,0), object2.GameObject);
    //selectedObject = allObjects.GetValue(Vector3(2,10,0);
    
    public void NewZone()
    {
        RenderSettings.skybox = hideBox;
    }

    public GameObject[] GetRooms()
    {
        return zoneRooms;
    }

    public void SpawnZone(Vector3 negativeCorner, int wallNumber)
    {
        Vector3 startPosition = new Vector3(negativeCorner.x + (wallHeight / 2),negativeCorner.y + (wallHeight / 2),negativeCorner.z + (wallHeight / 2));
        Vector3 currentPosition = startPosition;
        
        Vector3 nextLayer = new Vector3(0, 0, (wallLength / 2f));
        Vector3 nextPosition = new Vector3((wallLength / 2f), 0, 0);
        
        
        
        for (int i = 0, dic = 0; i < wallNumber; i++)
        {
            for (int j = 0; j < wallNumber; j++, dic++) // - 
            {
                currentPosition.x = nextPosition.x;
                
                Vector3 key = new Vector3(dic, j, 0);
                zoneDictionary.Add(key ,Instantiate(zoneRooms[Random.Range(0, zoneRooms.Length - 1)], currentPosition, Quaternion.identity));
                Debug.Log(zoneDictionary[key].name);
            }
            currentPosition += nextLayer;
            currentPosition.z = startPosition.z;

        }
    }
    
    
}
