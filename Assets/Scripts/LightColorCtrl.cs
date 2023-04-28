using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightColorCtrl : MonoBehaviour
{
     Color StartColor;
    public Color EndColor;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        StartColor = GetComponent<Light>().color;
    }

    // Update is called once per frame
    void Update()
    {
        //if (GetComponent<Light>()!=null&&GetComponent<Light>().color==StartColor)
        //{
        //    GetComponent<Light>().DOColor(EndColor, time);
        //}

        //if (GetComponent<Light>() != null && GetComponent<Light>().color == EndColor)
        //{
        //    GetComponent<Light>().DOColor(StartColor, time);
        //}
    }
}
