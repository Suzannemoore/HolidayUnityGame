using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject followMainObject;

    void Update()
    {
        // here is to set up the view for the user. 
        transform.position = followMainObject.transform.position + new Vector3 (0,0,-15);
    }

}