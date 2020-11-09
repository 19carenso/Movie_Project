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
	static public float timeBoost;
	private VisualEffect smoke_vfx;
	float time4avg = 0;

	void Start()
	{
		smoke_vfx = GetComponent<Transform>().Find("smoke").gameObject.GetComponent<VisualEffect>(); //Vfx component to access to the shader's options
		agent = GetComponent<NavMeshAgent>(); // The agent is a component of the same GameObject (than this script)		
		bathtub = GameObject.Find("baignoire").transform;
		isBoosted = false;
		agent.destination = GameObject.Find("Robot2").transform.position;
		last_position = agent.transform.position;

	}

	void Update()
	{
		agent.destination = GameObject.Find("Robot2").transform.position;
		time4avg += Time.deltaTime;
		if (time4avg > 0.1)
		{
			time4avg -= (float)0.1;
			Vector3 velocity = agent.transform.position - last_position;
			last_position = agent.transform.position;
			smoke_vfx.SetVector3("speed", 20 * velocity.magnitude * (new Vector3(0, 0, 1))); //Update of the smoke's speed based on the shadow's speed, (0,0,1) is linked to agent's direction
		}

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
	}
}
