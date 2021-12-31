using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packages : MonoBehaviour

{
    [SerializeField] Color32 presentActive = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 presentDeactive = new Color32(1, 1, 1, 1);

    // present status is false when games starts
    bool presentStatus;

    // create varible spriteRendererVar for a type SpriteRenderer
    SpriteRenderer spriteRendererVar;

    // create start method so it will happen at the start
    private void Start()
    {
        // GetComponent Sprite Renderer
        spriteRendererVar = GetComponent<SpriteRenderer>();
    }

    // package pick up timer
    [SerializeField] float pickUpTimer = 0.3f;


    // built method in unity. We are using 2D. Pulic class. 
    void OnCollisionEnter2D(Collision2D collision)
    {
        // the will appear when Santa sleigh has hit an object
        Debug.Log("CRASHED! but keep moving!");
    }

    // // built method in unity. We are using 2D. Pulic class.  
    void OnTriggerEnter2D(Collider2D collision)
    {
        // if use gets the package and doesn't already have one 
        if(collision.tag == "Present" && presentStatus == false)
        {
            Debug.Log("Present has been picked up! Hurry!");
            // when package is picked up
            presentStatus = true;
            // Here is where the present will change color when picked up by accessing the color property. 
            spriteRendererVar.color = presentActive;
            // after Santa drops off the package we will use destory() to get rid of the present
            Destroy(collision.gameObject, pickUpTimer);
            
        }

        if(collision.tag == "Recipient" && presentStatus)
        {
            Debug.Log("Hooray, present has been dropped off!");
            // when package is dropped back off on sligh
            presentStatus = false;
            // change color when package is dropped off. 
            spriteRendererVar.color = presentDeactive;

        }
    }


}
