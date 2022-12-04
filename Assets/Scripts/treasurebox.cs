using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasurebox : MonoBehaviour
{
    public GameObject CoinPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            gameObject.SetActive(false);
            Debug.Log("ouch");
            InvokeRepeating("Coin", 0, 0.1f);
            Destroy(gameObject);
            
        }
    }

    void Coin()
    {
        for(int i = 0; i < 6; i++)
        {
            Instantiate(CoinPrefab, transform.position, transform.rotation);
        }
        CancelInvoke();
        
    }
}
