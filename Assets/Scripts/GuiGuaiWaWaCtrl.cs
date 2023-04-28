using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiGuaiWaWaCtrl : MonoBehaviour
{   
    float timer;
    bool isDrag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (isDrag)
        //{
        //    timer += Time.deltaTime;
        //    if (timer >= 5)
        //    {
        //        GameManager.Instance.DestroyNum++;
        //        GameManager.Instance.isDoll = false;
        //        Destroy(gameObject);
        //    }
        //}
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RHand"))
        {
            //timer = 0;
            //GameManager.Instance.isDoll = true;
            //isDrag = true;
            if (GameManager.Instance.Number_Doll>0)
            {
                return;
            }
            GameManager.Instance.Number_Doll++;
            Destroy(gameObject);
        }       


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("RHand"))
        {
            //GameManager.Instance.isDoll = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RHand"))
        {          
            //GameManager.Instance.isDoll = false;
            //isDrag = false;
        }
    }
}
