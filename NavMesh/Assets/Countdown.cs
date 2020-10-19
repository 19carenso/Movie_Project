using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    static public float timeGame = 0;
    public Text textBox;
    public Text startBtnText;
    
    static public bool timerActive = true;


    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeGame.ToString("F2");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive)
        {
            timeGame += Time.deltaTime;
            textBox.text = timeGame.ToString("F2");
        }
    }

    public void TimerButton()
    {
        timerActive = !timerActive;
        startBtnText.text = timerActive ? "Pause" : "Start";
    }
}
