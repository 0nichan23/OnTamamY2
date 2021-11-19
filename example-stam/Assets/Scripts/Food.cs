using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject Particle;
    MeshRenderer MR;
    Color c;
    bool Eaten;

    private void Start()
    {
        MR = GetComponent<MeshRenderer>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E)&&Eaten==false)
        {
            Eaten = true;
            Instantiate(Particle, transform.position, transform.rotation);
            Debug.Log("food eaten");
            StartCoroutine(Eating());
            Destroy(this.gameObject,1f);
        }
    }

    IEnumerator Eating()
    {
        float alpha = 1;
        for (int i = 0; i < 20; i++)
        {
            alpha -= 0.05f;
            MR.material.color = new Color(1f, 1f, 1f, alpha);
            yield return new WaitForSeconds(0.05f);            
            
        }
    }
}
