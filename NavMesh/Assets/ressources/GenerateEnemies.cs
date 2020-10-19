using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    private float timeBoost;
    private int initialSpeed;
    private int initialAcceleration;
    static public float agentSpeed;
    static public float agentAcceleration;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
        initialSpeed = 3;
        initialAcceleration = 20; 
    }

    void Update()
    {
        timeBoost = 1 + Countdown.timeGame / 10;
        agentSpeed = initialSpeed * timeBoost;
        agentAcceleration = initialAcceleration * timeBoost;
    }
    IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {   
            if(Countdown.timerActive)
            {
                xPos = Random.Range(-50, 50);
                zPos = Random.Range(-50, 50);
                Instantiate(theEnemy, new Vector3(xPos, 1.5f, zPos), Quaternion.identity);
                
                yield return new WaitForSeconds(1f);
                enemyCount += 1;
            }
            else
            {
                Debug.Log("game is paused");
                yield return new WaitForSeconds(2);
            }       
        }   
    }
}
