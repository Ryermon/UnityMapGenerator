using System;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    int zoneNumber;
    private String zoneString;
    GameObject[] zoneWalls;
    GameObject[] zoneFloors;
    GameObject[] zoneCeilings;
    private Material hideBox;
    private static int numberOfWalls = 0;
    float zoneLength;
    float zoneHeight;

    
    
    Dictionary<Vector3, GameObject> zoneDictionary = new Dictionary<Vector3, GameObject>();
    //allObjects.Add(Vector3(2,10,0), object2.GameObject);
    //selectedObject = allObjects.GetValue(Vector3(2,10,0);
    
    public void NewZone()
    {
        RenderSettings.skybox = hideBox;
    }

    public GameObject[] GetWalls()
    {
        return zoneWalls;
    }

    public void SpawnZone(Vector3 negativeCorner, int wallNumber)
    {
        Vector3 position = new Vector3(0f,0f,0f);
        for (int i = 0; i < wallNumber; i++)
        {
            for (int j = 0; j < wallNumber; j++)
            {
                
                Instantiate(zoneWalls[i], negativeCorner, Quaternion.identity);
            }
            for (int j = 0; j < wallNumber; j++)
            {
                
                Instantiate(zoneWalls[i], negativeCorner, Quaternion.identity);
            }
        }
    }
    
    
}
