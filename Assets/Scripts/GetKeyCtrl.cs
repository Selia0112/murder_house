using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyCtrl : MonoBehaviour
{
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
        if (other.CompareTag("RHand"))
        {
            if (transform.name.Equals("DungeonKey"))
            {
                GameManager.Instance.DungeonKey = true;
                gameObject.SetActive(false);
            }
            if (transform.name.Equals("BasementKey"))
            {
                GameManager.Instance.BasementKey = true;
                gameObject.SetActive(false);
            }
            if (transform.name.Equals("BedroomKey"))
            {
                GameManager.Instance.BedroomKey = true;
                gameObject.SetActive(false);
            }
            if (transform.name.Equals("GateKey"))
            {
                GameManager.Instance.GateKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
