using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget_2 : MonoBehaviour
//==========================================================================
// The GameObject that have the NavMeshAgent component will move to the point where the mouse has cliqued.
// Second version (from Brackeys)
{
	public NavMeshAgent agent; // The NavMeshAgent can be given in the Inspector Windows
	public Camera cam;         // The Camera can be given in the Inspector Windows


	void Update()
	{
		if (Input.GetMouseButtonDown (0)) { // When the left button is down 
			RaycastHit hit;
			Ray ray;
			ray = cam.ScreenPointToRay(Input.mousePosition); // a ray is sent to catch a point in the scene 
			if( Physics.Raycast(ray, out hit) ){
				agent.SetDestination(hit.point); // the point becomes the destination of the moving agent !
				Debug.Log ("Moving agent to new destination..."); // just a message in console
			}
		}
	}
}