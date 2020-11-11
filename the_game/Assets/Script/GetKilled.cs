using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKilled : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject self;
    static public bool end = false; 
    private Transform player_view; //contient les infos sur la vue du joueur
    private Transform player_candle; // contient les infos sur la bougie du joueur (en fait sa main droite)
    private Transform selfTransform;
    private float distance;
    private Vector3 playerAim; // ce que vise le joueur cf start pour la construction
    private Vector3 player_ennemi;
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
        self = this.gameObject;
        health = 1f;
        selfTransform = GetComponent<Transform>();
        player_view = GameObject.Find("PlayerView").transform;
        player_candle = GameObject.Find("game_candle").transform;
        killing_precision_view = 0.8f;
        killing_precision_light = 0.8f;

         
        // bon ce vecteur est sensé contenir la direction tête --> bougie, donc correspondre a peu près 
        // à ce que le joueur vise avec son bras. Experimentalement il faudra peut-etre le decaler un peu 
        // pour un meilleur ressenti
    }

    // Update is called once per frame
    void Update()
    {
        playerAim = (player_candle.position - player_view.position).normalized;
        player_ennemi = (self.transform.position - player_view.position).normalized;
        distance = (selfTransform.position - player_view.position).magnitude;
        if (distance < 1.5)
        {
            Debug.Log("defeat");
            if(!GetKilled.end)
            {
                GameObject.Find("prefab_scene").SetActive(false);
                GetKilled.end = true;
                GameObject.Find("marat").GetComponent<AudioSource>().Play(0);
            }
            GameObject.Find("marat").GetComponent<Renderer>().enabled = true;
            self.SetActive(false);
        }
        //Debug.Log(Vector3.Dot(player_ennemi, player_view.forward));
        //Debug.Log(Vector3.Dot(playerAim, player_ennemi));
        if (Vector3.Dot(player_ennemi, player_view.forward) >= killing_precision_view & distance < 15)
        {
            if(Vector3.Dot(playerAim, player_ennemi)>=killing_precision_light)
            {
                health -= Time.deltaTime;        
            }
        }

        

        if (health < 0)
        {
            GameObject.Find("vanish").GetComponent<AudioSource>().Play(0);
            GenerateEnemies.enemyCount -= 1;
            Destroy(self);
            
            Debug.Log("Un ennemi a été tué");
            
        }
    }
}
