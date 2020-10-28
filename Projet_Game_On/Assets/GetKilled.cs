using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKilled : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject self;
    private Transform bathtub;
    private Transform selfTransform;
    public float health;
    void Start()
    {

        self = this.gameObject;
        health = 0.1f;
        selfTransform = GetComponent<Transform>();
        bathtub = GameObject.Find("bathtub").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if ((selfTransform.position - bathtub.position).magnitude < 1)
        {
            health -= Time.deltaTime;

        }

        if (health < 0)
        {
            GenerateEnemies.enemyCount -= 1;
            Destroy(self);
            
            // Debug.Log("Un ennemi a été tué");
            
        }
    }
}
