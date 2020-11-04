using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKilled : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject self;
    private Transform player_view; //contient les infos sur la vue du joueur
    private Transform player_candle; // contient les infos sur la bougie du joueur (en fait sa main droite)
    private Transform selfTransform;
    private Vector3 playerAim; // ce que vise le joueur cf start pour la construction
    private float killing_precision_view; // en gros la précision de visée avec le regard qu'il faut avoir pour tuer un ennemi
     // le hic c'est qu'on le fait avec un produit scalaire de quaternion. Or un tel produit scalaire avec des vecteurs
     // normés est à valeur dans [0, 1] plutot que [-1,1]. 
    private float killing_precision_light; // la précision de visée avec la bougie qu'il faut avoir pour tuer un ennemi.
    public float health;

    void Start()
    {

        GameObject theShadow = this.gameObject.transform.GetChild(0).gameObject; 
        // on récupuère la sphère pour plus tard en cas de bug
        // avec la visée..        
        
        health = 2f;
        selfTransform = GetComponent<Transform>();
        player_view = GameObject.Find("PlayerView").transform;
        player_candle = GameObject.Find("Controller (right)").transform;
        killing_precision_view = 0.05f;
        killing_precision_light = -0.95f;



        playerAim = (player_candle.position - player_view.position).normalized; 
        // bon ce vecteur est sensé contenir la direction tête --> bougie, donc correspondre a peu près 
        // à ce que le joueur vise avec son bras. Experimentalement il faudra peut-etre le decaler un peu 
        // pour un meilleur ressenti
    }

    // Update is called once per frame
    void Update()
    {
        if (Quaternion.Dot(player_view.rotation.normalized, this.transform.rotation) <= killing_precision_view)
        {
            if(Vector3.Dot(playerAim, new Vector3(player_view.rotation.x, player_view.rotation.y, player_view.rotation.z))<=killing_precision_light)
            {
                health -= Time.deltaTime;        
            }
        }

        

        if (health < 0)
        {
            GenerateEnemies.enemyCount -= 1;
            Destroy(self);
            
            // Debug.Log("Un ennemi a été tué");
            
        }
    }
}
