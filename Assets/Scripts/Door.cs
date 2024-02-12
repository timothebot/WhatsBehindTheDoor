using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rooms;
    
    public void Open()
    {
        var randomRoom = UnityEngine.Random.Range(0, rooms.Length);
        RoomManager.Instance.SpawnRoom(rooms[randomRoom]);
    }
}
