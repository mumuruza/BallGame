using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    [SerializeField]
    private List <Room> rooms;
    [SerializeField]
    private float moveSpeed;

    private Camera camera;
    private Queue<Room> roomsQueue;
    private Room last; 
    private void Start()
    {
        camera = Camera.main;
        float offset = 0;
        roomsQueue = new Queue<Room>();
        foreach (var i in rooms)
        {
            i.transform.position = transform.position +  Vector3.right * (offset + i.Width/2);
            offset += i.Width;
            i.RegenerateRoom();
            roomsQueue.Enqueue(i);
            last = i;
        }
    }

    private void Update()
    {
        MoveRooms();
        RegenerateRoomIfNeed();
    }

    private void MoveRooms()
    {
        foreach (var i in rooms)
        {
            i.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            
        }
    }

    private void RegenerateRoomIfNeed() 
    {
        if (roomsQueue.Peek().IsOutsideViewPort(camera))
        {
            Room tmp = roomsQueue.Dequeue();
            tmp.transform.position = new Vector3(last.transform.position.x + last.Width/2 + tmp.Width/2, tmp.transform.position.y);
            tmp.RegenerateRoom();
            last = tmp;
            roomsQueue.Enqueue(last);
        }
    }
}

