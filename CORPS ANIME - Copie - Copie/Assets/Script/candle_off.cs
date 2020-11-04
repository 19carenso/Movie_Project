using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class candle_off : MonoBehaviour
{
    public float magmax;
    public float candle_cooldown;
    public float time_avg;

    public static bool is_on;

    private Vector3 last_position;
    private float time4avg;
    private float cooldown = 0;
    private Vector3 velocity = new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        last_position = this.gameObject.transform.position;
        magmax = 1;
        candle_cooldown = 1;
        time_avg = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        // UnityEngine.Debug.Log(cooldown);
        time4avg += Time.deltaTime;
        if (time4avg > time_avg)
        {
            velocity = (this.gameObject.transform.position - last_position) / time4avg;
            time4avg = 0;
            UnityEngine.Debug.Log(velocity.magnitude);
            last_position = this.gameObject.transform.position;
        }
        if (cooldown > 0)
        {
            this.turn_off();
            cooldown -= Time.deltaTime;
            // UnityEngine.Debug.Log(cooldown);
        }
        else
        {
            this.turn_on();
            if (velocity.magnitude > magmax)
            {
                cooldown = candle_cooldown;
                velocity = new Vector3(0f, 0f, 0f);
            }
        }
    }
    void turn_off()
    {
        GetComponent<Transform>().Find("light").GetComponent<Light>().enabled = false;
        is_on = false;
        GetComponent<Transform>().Find("red_flame_0 (4)").GetComponent<Renderer>().enabled = false;
    }
    void turn_on()
    {
        GetComponent<Transform>().Find("light").GetComponent<Light>().enabled = true;
        is_on = true;
        GetComponent<Transform>().Find("red_flame_0 (4)").GetComponent<Renderer>().enabled = true;
    }
}
