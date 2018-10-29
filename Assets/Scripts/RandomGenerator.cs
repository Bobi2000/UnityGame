using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public int MaxRooms = 6;
    public int MinRooms = 3;

    [Header("Rooms:")]
    public List<GameObject> Rooms = new List<GameObject>();

    private float CoordinatesX = 18;

    private int SpawnedRooms = 0;

    private bool IsGeneratedCorrectly = false;

    private void Awake()
    {
        this.GenerateRooms();
    }
    //1-Down
    //2-Up
    //3-Left
    private void GenerateRooms()
    {
        var currentVector3 = new Vector3(18, 0, 0);
        var roomToGenerate = 0;

        Room lastRoom = null;

        while (true)
        {
            if (this.SpawnedRooms == this.MaxRooms)
            {
                this.IsGeneratedCorrectly = true;
            }
            if (this.IsGeneratedCorrectly)
            {
                break;
            }
            
            this.SpawnedRooms++;
            
            var room = new Room(currentVector3.x, currentVector3.y, currentVector3.z, roomToGenerate);

            var position = new Vector3(this.CoordinatesX, 0, 0);
            
            Instantiate(this.Rooms[roomToGenerate], currentVector3, Quaternion.identity);

            lastRoom = room;

            if (lastRoom.Index == 0)
            {
                roomToGenerate = 1;
                currentVector3.y += 10;
            }

        }
        //for (int i = 0; i < this.MaxRooms; i++)
        //{
        //    var position = new Vector3(this.CoordinatesX, 0, 0);
        //    Instantiate(this.Rooms[0], position, Quaternion.identity);

        //    this.CoordinatesX += 18;
        //}
    }
}

public class Room
{
    public int Index { get; set; }

    public float PosX { get; set; }
    public float PosY { get; set; }
    public float PosZ { get; set; }

    public Room(float x, float y, float z, int index)
    {
        this.PosX = x;
        this.PosY = y;
        this.PosZ = z;
        this.Index = index;
    }

    public Vector3 GetPosition()
    {
        var position = new Vector3(PosX, PosY, PosZ);
        return position;
    }
}


