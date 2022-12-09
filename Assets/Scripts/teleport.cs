using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform otherteleport;
    private Vector3 other_place;
    public GameObject player;
    public static BoxCollider boxcollider;
    public static bool isTeleporting = false;

    // Start is called before the first frame update
    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
        other_place = otherteleport.position;
    }

    // Update is called once per frame
    void Update()
    {
        //...
    }

    void OnCollisionEnter(Collision other)
    {
        
        Debug.Log("enter");
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(Trans(other));
        }
        
    }
    

    IEnumerator Trans(Collision other)
    {
        if (isTeleporting == true)
        {
            other.gameObject.transform.position = new Vector3(other_place.x, 1.7f, other_place.z);
            Player.controller.enabled = false;
            isTeleporting = false;
            yield return new WaitForSeconds(0.5f);
            Player.controller.enabled = true;
            
        }
    }

}
