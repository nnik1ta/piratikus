using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [Header("Скорость перемещения персонажа")]
    public float speed = 7f;
    [Header("На земле")]
    public bool IsGround;
    public Rigidbody rb;
    [Header("Скорость перемещения персонажа")]
    public float runSpeed = 7f;
    [Header("Сила прыжка")]
    public float jumpforce = 200f;
    public int coins;
    public Text TextCoins;
    public CapsuleCollider crouch;
    public float C1;
    public float C2;
    public Camera cam;
    /*public float x;
    public float y;
    public float z;*/
    float SX, SZ; 
    float SY;
    public GameObject player;
    public bool IsCrouch;
    public bool IsShift;
    
  

    private void Start()
    {
        //if (PlayerPrefs.HasKey("Coins"))
        //{
        //coins = PlayerPrefs.GetInt("Coins");
        //TextCoins.text = coins.ToString();
        //}
        
        
    }
    private void Update()
    {
        GetInput();
        SZ = player.transform.position.z;
        SX = player.transform.position.x;
        SY = player.transform.position.y;
        if (IsCrouch == true)
        {
            runSpeed = 6f;
            speed = 3f;
        }
        if (IsCrouch == false)
        {
            runSpeed = 10f;
            speed = 6f;

        }
    }

    private void GetInput()
    {

            if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                IsShift = true;
                transform.localPosition += transform.forward * runSpeed * Time.deltaTime;
            }
            else
            {
                IsShift = false;
                transform.localPosition += transform.forward * speed * Time.deltaTime;
            }
        }
        

        if (Input.GetKey(KeyCode.S))
        {
           /* if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += -transform.forward * runSpeed * Time.deltaTime;
            }
            else
            {*/
                transform.localPosition += -transform.forward * speed * Time.deltaTime;
           /* }*/

        }

        if (Input.GetKey(KeyCode.A))
        {
           /* if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += -transform.right * runSpeed * Time.deltaTime;
            }
            else
            {*/
                transform.localPosition += -transform.right * runSpeed / 2 * Time.deltaTime;
            /*}*/
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            /*if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += transform.right * runSpeed * Time.deltaTime;
            }
            else
            {*/
                transform.localPosition += transform.right * speed * Time.deltaTime;
           /* }*/
            
        }
        if (IsGround  && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpforce);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            IsCrouch = true;
            crouch.enabled = false;
            cam.transform.position = new Vector3(SX, SY - C1, SZ);
        }  
        else 
        {
            IsCrouch = false;
            crouch.enabled = true;
            cam.transform.position = new Vector3(SX, SY + 1, SZ);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            IsGround = true;
        }
        else
        {
            IsGround = false;
        }
      
        if (collision.gameObject.tag == "DeadZone")
        {
            transform.position = new Vector3(1, 2, 2);
           
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "booba")
        {
            coins++;
            other.gameObject.SetActive(false);
            TextCoins.text = coins.ToString();
            //PlayerPrefs.SetInt("Coins", coins);
        }
        
    }
    
    
}
