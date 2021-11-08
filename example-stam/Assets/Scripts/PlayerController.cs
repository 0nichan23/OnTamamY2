using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController CC;
    public float MovementSpeed = 10;
    private GameObject Cockroach;
    private GameObject TheCamera;

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationX;
    float rotationY;

    public float JumpPower = 10;
    public float JumpTime = 0.5f;
    public float Gravity = 10;
    float jumptimeleft;

    // Start is called before the first frame update
    void Start()
    {
        TheCamera = Camera.main.gameObject;
        Cockroach = CC.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Look();
        Jump();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CC.Move(Cockroach.transform.forward * MovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CC.Move(-Cockroach.transform.forward * MovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            CC.Move(Cockroach.transform.right * MovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            CC.Move(-Cockroach.transform.right * MovementSpeed * Time.deltaTime);
        }
    }
    void Look()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        Cockroach.transform.localRotation = Quaternion.Euler(new Vector3(0, rotationX, 0));
        TheCamera.transform.parent.parent.localRotation = Quaternion.Euler(new Vector3(-rotationY, 0, 0));

        RaycastHit hit;
        if (Physics.Raycast(TheCamera.transform.parent.parent.position, -TheCamera.transform.parent.parent.forward, out hit, 0.5f))
        {
            TheCamera.transform.parent.position = hit.point;
        }
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && CC.isGrounded)
        {
            jumptimeleft = JumpTime;
        }
        if (jumptimeleft > 0)
        {
            jumptimeleft -= Time.deltaTime;
            CC.Move(Vector3.up * JumpPower * Time.deltaTime);
        }
        if (jumptimeleft<=0&&!CC.isGrounded)
        {
            CC.Move(-Vector3.up * Gravity * Time.deltaTime);
        }

        
    }
}
