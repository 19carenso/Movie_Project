using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour
{
    public float intensity_prop;
    public float freq;
    public float random_offset;

    private static bool is_on;

    private float intensity_init;
    private float time;
    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        intensity_init = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime*(1 - random_offset * Random.Range(-random_offset, random_offset));
        is_on = candle_off.is_on;
        if (is_on)
        {
            light.intensity = intensity_init + intensity_init * intensity_prop * Mathf.Sin(time * 2 * Mathf.PI * freq);
        }
        else
        {
            light.intensity = 0f;
        }
    }
}
