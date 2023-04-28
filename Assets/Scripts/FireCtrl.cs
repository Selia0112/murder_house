using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCtrl : MonoBehaviour
{
    public GameObject CanvasGo;
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
            if (GameManager.Instance.Number_Doll>0)
            {
                CanvasGo.SetActive(true);
                CanvasGo.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Destroyed  " + GameManager.Instance.Number_Doll + "  ghost dolls";
                GameManager.Instance.DestroyNum += GameManager.Instance.Number_Doll;
                GameManager.Instance.Number_Doll = 0;
                
            }
            else
            {
                CanvasGo.SetActive(true);
                CanvasGo.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "There are currently no ghost dolls in the backpack that can be destroyed";
            }
            Invoke("CloseRemainText", 5);
        }
    }

    void CloseRemainText()
    {
        CanvasGo.SetActive(false);
    }
}
