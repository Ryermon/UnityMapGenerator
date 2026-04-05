/*
Ryer Triezenberg
4/4/2026

 */

using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private Vector3 roomCenter = new Vector3();
    
    [SerializeField]
    private GameObject wallA;
    
    //Unused as of 4/1/2026
    [SerializeField]
    private GameObject wallB;
    

    public void CallRoom()
    {
        CreateRoom(roomCenter, wallA);
    }
    
    public void CallRoomRand()
    {
        CreateRoom(wallA);
    }
    
    
    
    private void CreateRoom(Vector3 centerPosition, GameObject wall)
    {
        //Calculate Size of room
        Vector3 wallSize = CalculateObjectSize(wall);
        
        float halfWidth; // Check and set if x or z is Wall width rather than Wall
        if(wallSize.x > wallSize.z)
            halfWidth = wallSize.x / 2.0f;
        else
            halfWidth = wallSize.z / 2.0f;
        
        float halfHeight = wallSize.y / 2.0f;
        
        Quaternion wallRotation = new Quaternion(0f,0f,0f,1);
        
        
        //Left Wall
        Vector3 wallPosition = new Vector3(centerPosition.x - halfWidth , centerPosition.y, centerPosition.z);
        GameObject leftWall = Instantiate( wall, wallPosition, Quaternion.identity );
        leftWall.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
        Debug.Log("Left Wall instantiated at" + wallPosition);
        
        //Right Wall
        wallPosition = new Vector3(centerPosition.x + halfWidth, centerPosition.y, centerPosition.z);
        GameObject rightWall = Instantiate( wall, wallPosition, Quaternion.identity );
        rightWall.transform.Rotate(0.0f, 270.0f, 0.0f, Space.Self);
        Debug.Log("Right Wall instantiated at" + wallPosition);
        
        //Front Wall
        wallPosition = new Vector3(centerPosition.x, centerPosition.y, centerPosition.z - halfWidth);
        GameObject frontWall = Instantiate( wall, wallPosition, Quaternion.identity );
        frontWall.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        Debug.Log("Front Wall instantiated at" + wallPosition);
        
        //Back Wall
        wallPosition = new Vector3(centerPosition.x, centerPosition.y, centerPosition.z + halfWidth);
        GameObject backWall = Instantiate( wall, wallPosition, Quaternion.identity );
        backWall.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        Debug.Log("Back Wall instantiated at" + wallPosition);
    }

    //Random Vector3
    void CreateRoom(GameObject wall)
    {
        Vector3 newCenter = new Vector3(Random.Range(-15f, 15f), Random.Range(0f, 10.0f), Random.Range(-10f, 20.0f));
        CreateRoom(newCenter, wall);
        
    }

    //Calculate the Bounds of the GameObject
    Vector3 CalculateObjectSize(GameObject calObject)
    {
        MeshRenderer mRenderer = calObject.GetComponent<MeshRenderer>();
        
        //Fetch Vector3 of the Mesh for Object
        Vector3 mSize = mRenderer.bounds.size;
        Debug.Log("Object Vector3: " + mSize);
        return mSize;
    }
}
