using UnityEngine;
using UnityEngine.Events;

public class RoomContainer : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;
    
    [SerializeField] private UnityEvent _onRoomActivated;
    
    [SerializeField] private Camera _camera;
    
    public void ActivateRoom()
    {
        _onRoomActivated.Invoke();
        Camera.main.transform.position = _cameraPosition.position;
        _camera = Utility.GetSecondCamera();
    }
    
    private void Update()
    {
        // check if we clicked on a door
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            // layer mask to only hit doors
            if (!Physics.Raycast(ray, out var hit)) return;
            Debug.Log(hit.collider.name);
            var roomContainer = hit.collider.GetComponent<Door>();
            if (roomContainer == null) return;

            // TODO: sound of closed door
            if (!RoomManager.Instance.IsRoomClear())
                return;
            roomContainer.Open();
            Destroy(gameObject);
        }
    }
}
