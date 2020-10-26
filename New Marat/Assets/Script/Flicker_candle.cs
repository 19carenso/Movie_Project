using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker_candle : MonoBehaviour
{
    float intensity = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        intensity = GetComponent<Transform>().Find("light").GetComponent<Light>().intensity;
        GetComponent<Renderer>().material.SetColor("_EmissionColor",Color.white*intensity/10);
    }
}
