using UnityEngine;

public class Climb : MonoBehaviour
{
    CharacterController Cc;
    public bool inside = false;
    public float speed = 3.2f;
    PlayerController Player;
    Animator ani;
    void Start()
    {
        Player = transform.parent.GetComponent<PlayerController>();
        ani = GetComponent<Animator>();
        inside = false;
        Cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (inside == true)
        {
            Debug.Log("inside");
            Climbing();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag == "Climbable")
        {
            Player.enabled = false;
            inside = true;
            ani.SetBool("Climb", true);
        }
    }

    private void OnTriggerExit(Collider other)
    { 
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
