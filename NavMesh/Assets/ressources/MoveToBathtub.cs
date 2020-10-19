using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using UnityEngine.VFX;

public class MoveToBathtub : MonoBehaviour
//==========================================================================
// The GameObject that have the NavMeshAgent component will move to the point where the mouse has cliqued.
// first version (from Sykoo)
{
	private NavMeshAgent agent;
	private Vector3 last_position;
	// we keep track of the agent's position to get the velocity when we it's needed
    private Transform bathtub;
	private bool isBoosted;
	private	VisualEffect smoke_vfx;
	static public float timeBoost;
	

	void Start()
	{
		agent = GetComponent<NavMeshAgent>(); // The agent is a component of the same GameObject (than this script)
		
		smoke_vfx = GetComponent<Transform>().Find("smoke").gameObject.GetComponent<VisualEffect>(); //Vfx component to access to the shader's options
		bathtub = GameObject.Find("Bathtub").transform;
		isBoosted = false;
		agent.destination = bathtub.position;

	}

	void Update()
	{
		Vector3 velocity = agent.transform.position - last_position;

		smoke_vfx.SetVector3("speed", velocity*100); //Update of the smoke's speed based on the shadow's destination

		if (!isBoosted)
        {
			agent.speed = GenerateEnemies.agentSpeed;
			agent.acceleration = GenerateEnemies.agentAcceleration;
			isBoosted = !isBoosted;
        }

		if(Countdown.timerActive)
        {
			agent.isStopped = false;
		}
		
		if(!Countdown.timerActive)
        {
			agent.isStopped = true;
        }



		last_position = agent.transform.position;
	}
}
