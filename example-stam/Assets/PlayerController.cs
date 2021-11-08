using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController CC;
    public float MovementSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CC.Move(Vector3.forward*MovementSpeed*Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CC.Move(Vector3.back * MovementSpeed * Time.deltaTime);
        }
    }
}
