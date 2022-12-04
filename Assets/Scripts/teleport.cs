using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform otherteleport;
    public GameObject a;
    public GameObject player;
    public static BoxCollider boxcollider;

    // Start is called before the first frame update
    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
        GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Player.collider.enabled = false;
            Debug.Log("Player");
            Player.controller.enabled = false;
            other.gameObject.transform.position = otherteleport.gameObject.transform.position;
            Debug.Log("1");
            ExecuteAfterTime(3f);
            Player.controller.enabled = true;
        }

        ExecuteAfterTime(2f);
        //boxcollider.enabled = true;
    }

    public IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
 
     // Code to execute after the delay
    }

}
