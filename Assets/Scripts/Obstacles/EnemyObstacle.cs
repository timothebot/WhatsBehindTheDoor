using UnityEngine;

public class EnemyObstacle : MonoBehaviour, IObstacleInterface
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    
    public void Execute()
    {
        Debug.Log("EnemyObstacle.Execute()");
        RoomManager.Instance.AddObstacle();
        Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
    }
}
