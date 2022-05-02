using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerControl : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    [Header("Чувствительность")]
    public float sensivityMouse = 150f;

    public Transform Player;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
   

    
    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensivityMouse * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensivityMouse * Time.deltaTime;

        Player.Rotate(mouseX * new Vector3(0, 1, 0));

        transform.Rotate(-mouseY * new Vector3(1, 0, 0));
        
    }
}
