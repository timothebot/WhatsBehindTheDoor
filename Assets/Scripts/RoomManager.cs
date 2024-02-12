using UnityEngine;

public class RoomManager : Singleton<RoomManager>
{
    [SerializeField]
    private GameObject[] rooms;
    
    [SerializeField]
    private int _obstacleCount = 0;
    
    public void AddObstacle(int count = 1)
    {
        _obstacleCount += count;
    }
    
    public void RemoveObstacle()
    {
        _obstacleCount--;
    }
    
    public bool IsRoomClear()
    {
        return _obstacleCount == 0;
    }

    private void Start()
    {
        var randomRoom = UnityEngine.Random.Range(0, rooms.Length);
        SpawnRoom(rooms[randomRoom]);
    }
    
    public void SpawnRoom(GameObject room)
    {
        var newRoom = Instantiate(room, Vector3.zero, Quaternion.identity);
        newRoom.transform.SetParent(transform);
        newRoom.transform.localPosition = Vector3.zero;
        newRoom.GetComponent<RoomContainer>().ActivateRoom();
    }
}
