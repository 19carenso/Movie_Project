using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour
//==========================================================================
// The GameObject that have the NavMeshAgent component will move to the point where the mouse has cliqued.
// first version (from Sykoo)
{
	private NavMeshAgent agent;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>(); // The agent is a component of the same GameObject (than this script)
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) { // When the left button is down 
			RaycastHit hit; // a ray is sent to catch a point in the scene 
			if( Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100) ){
				agent.destination = hit.point;
				Debug.Log ("Moving agent to new destination..."); // just a message in console
			}
		}
	}
}