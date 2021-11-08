using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController CC;
    public Animator Anim;
    public float MovementSpeed = 10;
    LayerMask layer;
    private GameObject TheCamera;
    private GameObject Cockroach;

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;

    public float JumpTime = 0.5f;
    public float JumpPower = 2;
    public float Gravity = 5;
    float jumpTimeLeft;
    float TimeFalling;

    public LayerMask CameraLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        TheCamera = Camera.main.gameObject;
        Cockroach = CC.gameObject;
        Anim = Cockroach.GetComponent<Animator>();
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
        bool walk = false;
        if (Input.GetKey(KeyCode.W))
        {
            CC.Move(Cockroach.transform.forward*MovementSpeed*Time.deltaTime);
            walk = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CC.Move(-Cockroach.transform.forward * MovementSpeed * Time.deltaTime);
            walk = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CC.Move(Cockroach.transform.right * MovementSpeed * Time.deltaTime);
            walk = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            CC.Move(-Cockroach.transform.right * MovementSpeed * Time.deltaTime);
            walk = true;
        }
        if (walk) { Anim.SetBool("Walk", true); }
        else { Anim.SetBool("Walk", false); }
    }
    void Look()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        Cockroach.transform.localRotation = Quaternion.Euler(new Vector3(0, rotationX, 0));
        TheCamera.transform.parent.parent.localRotation = Quaternion.Euler(new Vector3(-rotationY, 0, 0));
        RaycastHit hit;
        if (Physics.Raycast(TheCamera.transform.parent.parent.position, TheCamera.transform.parent.parent.TransformDirection(Vector3.back), out hit, 0.5f, CameraLayerMask))
        {
            TheCamera.transform.parent.position = hit.point;
        }
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && CC.isGrounded)
        {
            jumpTimeLeft = JumpTime;
            Anim.SetTrigger("Jump");
        }
        if (jumpTimeLeft > 0)
        {
            jumpTimeLeft -= Time.deltaTime;
            CC.Move(Vector3.up * jumpTimeLeft * JumpPower * Time.deltaTime);
        }
        if (jumpTimeLeft <= 0 && !CC.isGrounded)
        {
            Anim.SetTrigger("Fall");
            TimeFalling += Time.deltaTime;
            CC.Move(-Vector3.up * Gravity * TimeFalling * Time.deltaTime);
        }
        if (CC.isGrounded)
        {
            TimeFalling = 0;
            Anim.SetBool("OnFloor", true);
        }
        else Anim.SetBool("OnFloor", false);
    }

    void Climb()
    {
        if (gameObject.layer == layer)
        {
            //attach player to the layer as long as its on itב
        }
    }
}
