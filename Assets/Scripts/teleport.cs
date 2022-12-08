using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform otherteleport;
    public GameObject player;
    public static BoxCollider boxcollider;
    public static bool isTeleporting = false;

    // Start is called before the first frame update
    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
        //GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //...
    }

    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("enter");
        if(other.gameObject.tag == "Player")
        {
            Player.controller.enabled = false;
            Trans(other);
            Player.controller.enabled = true;
            //isTeleporting = true;
        }
        
    }
    

    void Trans(Collider other)
    {
        if (isTeleporting == true)
        {
            other.gameObject.transform.position = otherteleport.gameObject.transform.position;
            isTeleporting = false;
            ExecuteAfterTime(6f);
            
        }
    }

    public IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

}
