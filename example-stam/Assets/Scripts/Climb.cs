using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    CharacterController Cc;
    bool inside = false;
    public float speed = 3.2f;
    PlayerController Player;
    Animator ani;
    void Start()
    {
        Player = transform.parent.GetComponent<PlayerController>();
        ani = Player.GetComponent<Animator>();
        inside = false;
        Cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (inside)
        {
            Climbing();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sadw");
        if (other.gameObject.tag == "Climbable")
        {
            Player.enabled = false;
            inside = true;
            ani.SetBool("Climb", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("sadw");
        if (other.gameObject.tag == "Climbable")
        {
            Player.enabled = true;
            inside = false;
            ani.SetBool("Climb", false);
        }
    }

    void Climbing()
    {
        if (Input.GetKey("w"))
        {
            Cc.Move(Vector3.up * speed * Time.deltaTime);


        }
        else if (Input.GetKey("s"))
        {
            Cc.Move(Vector3.down * speed * Time.deltaTime);
        }
    }
}
