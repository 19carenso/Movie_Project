using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    static public int enemyCount;
    private float timeBoost;
    private float initialSpeed;
    private float initialAcceleration;
    private float spawnRate;
    static public float agentSpeed;
    static public float agentAcceleration;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
        initialSpeed = 0.5f;
        initialAcceleration = 2f;
        spawnRate = 5f;
    }

    void Update()
    {
        timeBoost = 1 + Countdown.timeGame / 10;
        agentSpeed = initialSpeed * timeBoost;
        agentAcceleration = initialAcceleration * timeBoost;
        spawnRate = spawnRate / timeBoost; 
    }

    public void EnemyDead()
    {
        enemyCount -= 1;
    }
    IEnumerator EnemyDrop()
    {
        while (enemyCount < 100)
        {   
            if(Countdown.timerActive)
            {
                xPos = Random.Range(-5, 4);

                zPos = Random.Range(-4, 5);

                Instantiate(theEnemy, new Vector3(xPos, 1f, zPos), Quaternion.identity);
                
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
