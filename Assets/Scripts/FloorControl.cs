using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorControl : MonoBehaviour
{
    public static BoxCollider boxcollider;
    // Start is called before the first frame update
    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //...
    }

    void OnCollisionEnter(Collision other)
    {
        
        Debug.Log("floor");

        if(other.gameObject.tag == "Player")
        {
            teleport.isTeleporting = true;
        }
        
    }
}
