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
    private float prob_spawn_behind;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
        initialSpeed = 0.5f;
        initialAcceleration = 2f;
        spawnRate = 5f;
        prob_spawn_behind = 0.5f;
        enemyCount = 0;

    }

    void Update()
    {
        timeBoost = 1 + Countdown.timeGame / 20;
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
        while (true)
        {
            //Debug.Log(enemyCount);
            if(Countdown.timerActive && enemyCount < 1)
            {
                // Bon on va faire en sorte que les ennemies spawn moins souvent dans le dos du joueur psk franchement 
                // la position des fenêtes est pas hyper cool
                // la géométrie de la pièce dans le référentiel du cylindre est un grand rectangle  de x -310 à -295 et de z -4.8 à 12.7
                // et le petit rectangle de la maison de x -308 à -298 et de -1.65 à 11.5

                // pour faciliter le jeu on peut commencer par interdire le spawn dans la zone juste dans le dos du joueur
                // mais les monstres pourraient toujours passer par les fenetres

                xPos = (int)Random.Range(-12f, 12f);

                if (xPos >= -10 & xPos <= 10)
                {
                    if (Random.value <= prob_spawn_behind) // pour interdire la zone dont je parlais tout à l'heure 
                                                          //il faudrait baisser cette zone en réduisant le flottant prob_spawn_behind
                    {
                        zPos = (int)Random.Range(-12f, 12f);
                    }

                    else
                    {
                        zPos = (int)Random.Range(10f, 12f);
                    }
                    
                }

                else
                {
                    zPos = (int)Random.Range(-12f, 12f);
                }


                Instantiate(theEnemy, new Vector3(xPos, 1f, zPos), Quaternion.identity);
                
                yield return new WaitForSeconds(1f);
                enemyCount += 1;
            }
            else
            {
                //Debug.Log("game is paused");
                yield return new WaitForSeconds(2);
            }       
        }   
    }
}
