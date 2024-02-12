using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // check if we clicked on self
            var ray = Utility.GetSecondCamera().ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit)) return;
            if (gameObject != hit.collider.gameObject) return;
            RoomManager.Instance.RemoveObstacle();
            Destroy(gameObject);
        }
    }
}
