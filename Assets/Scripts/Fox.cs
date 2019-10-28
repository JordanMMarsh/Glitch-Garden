using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour { 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            if (otherObject.gameObject.tag == "Gravestone")
            {
                GetComponent<Animator>().SetBool("isJumping", true);
            }
            else
            {
                GetComponent<Attacker>().Attack(otherObject);
            }            
        }
    }

    public void JumpFinished()
    {
        GetComponent<Animator>().SetBool("isJumping", false);
    }
}
