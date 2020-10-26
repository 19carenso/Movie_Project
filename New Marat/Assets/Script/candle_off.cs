using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class candle_off : MonoBehaviour
{
    private Vector3 last_position;
    private float time4avg;
    // Start is called before the first frame update
    void Start()
    {
        last_position = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        time4avg += Time.deltaTime;
        if (time4avg > 0.1)
        {
            time4avg -= (float)0.1;
            Vector3 velocity = (this.gameObject.transform.position - last_position) / time4avg;
            UnityEngine.Debug.Log(velocity);
            last_position = this.gameObject.transform.position;
            if (velocity.magnitude > 20)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
