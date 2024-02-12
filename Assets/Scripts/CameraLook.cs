using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 100f;
    [SerializeField] private Vector2 _maxLook = new Vector2(50, 30);
    
    // look should get faster the closer we look to the center
    private float _sensitivityMultiplier = 1f;
    
    private float _xRotation = 0f;
    private float _yRotation = 0f;
    
    private void Start()
    {
    }
    
    private void Update()
    {
        // cursor distance to when rotation is 0, 0
        var cursorDistance = Vector2.Distance(new Vector2(Screen.width / 2f, Screen.height / 2f),
            new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        
        _sensitivityMultiplier = Mathf.Clamp(cursorDistance / 100f, 0.5f, 1f);
        
        
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity * _sensitivityMultiplier * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity * _sensitivityMultiplier * Time.deltaTime;
        
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -_maxLook.x, _maxLook.x);
        
        _yRotation += mouseX;
        _yRotation = Mathf.Clamp(_yRotation, -_maxLook.y, _maxLook.y);
        
        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
    }
    
}
