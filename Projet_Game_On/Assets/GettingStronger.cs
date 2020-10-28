using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingStronger : MonoBehaviour
{
    //Stats of the shadows that get to grow with time that we will initialize at time = 0 to a certain value

    public float life = 3;
    public float speed = 1f;

    public float game_time = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        game_time = Countdown.timeGame;
    }

    // Update is called once per frame
    void Update()
    {
        game_time = Countdown.timeGame;

    }
}
