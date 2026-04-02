/*
Ryer Triezenberg
4/1/2026


Creator is the one interacting with the tools in the editor.
Player is the one interacting with the objects in the gameView.
 */

using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    //Get values from creator
    [SerializeField]
    public Button RoomButton;

    [SerializeField]
    public Vector3 RoomCenter = new Vector3(0, 0, 0);
    
    [SerializeField]
    public GameObject WallA;
    
    //Will remain unused as of 4/1/2026
    [SerializeField]
    public GameObject WallB;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RoomButton.onClick.AddListener(() => CreateRoom(RoomCenter, WallA));
    }
    
    
    //Class will instantiate Object known as Room
    void CreateRoom(Vector3 CenterPosition, GameObject Wall)
    {
        Vector3 WallSize = CalculateObjectSize(Wall);
        float halfX = WallSize.x / 2.0f;
        float halfY = WallSize.y / 2.0f;
        
        //Left Wall
        Vector3 WallPosition = new Vector3(RoomCenter.x - halfX , RoomCenter.y, RoomCenter.z);
        Instantiate( WallA, WallPosition, Quaternion.identity);
        //Right Wall
        WallPosition = new Vector3(RoomCenter.x + halfX, RoomCenter.y, RoomCenter.z);
        Instantiate( WallA, WallPosition, Quaternion.identity);
        
        //Front Wall
        WallPosition = new Vector3(RoomCenter.x, RoomCenter.y - halfY, RoomCenter.z);
        Instantiate( WallA, WallPosition, Quaternion.identity);
        
        //Back Wall
        WallPosition = new Vector3(RoomCenter.x, RoomCenter.y + halfY, RoomCenter.z);
        Instantiate( WallA, WallPosition, Quaternion.identity);
    }

    //Calculate the Bounds of the GameObject
    Vector3 CalculateObjectSize(GameObject Object)
    {
        MeshRenderer renderer = Object.GetComponent<MeshRenderer>();
        Vector3 m_Size;
        
        

        //Fetch the size of the 
        m_Size = renderer.bounds.size;

        //Output to the console the size of the Collider volume
        return m_Size;
    }
}
