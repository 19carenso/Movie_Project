using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class MoveToBathtub : MonoBehaviour
//==========================================================================
// The GameObject that have the NavMeshAgent component will move to the point where the mouse has cliqued.
// first version (from Sykoo)
{
	private NavMeshAgent agent;
    private Transform bathtub;
	private bool isBoosted;
	static public float timeBoost;
	

	void Start()
	{
		agent = GetComponent<NavMeshAgent>(); // The agent is a component of the same GameObject (than this script)
		
		bathtub = GameObject.Find("Bathtub").transform;
		isBoosted = false;
		agent.destination = bathtub.position;
		
	}

	void Update()
	{
		if(!isBoosted)
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
		
		

	}
}
