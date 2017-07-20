// Patrol.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

/* Hi Nick! This script is for creating a really basic patrolling AI using the [Unity NavMesh](https://docs.unity3d.com/Manual/nav-BuildingNavMesh.html)
It takes an array of Transforms, aka the positions of objects in the scene, and then uses the NavMesh Agent component, which is to be applied to the object
you want to move on a patrol, and makes it find the next one! V simple, v useful. */

public class Patrol : MonoBehaviour {

	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;


	void Start () {
		agent = GetComponent<NavMeshAgent>();

		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = false;

		GotoNextPoint();
	}


	void GotoNextPoint() {
		// Returns if no points have been set up
		if (points.Length == 0)
			return;

		// Set the agent to go to the currently selected destination.
		agent.destination = points[destPoint].position;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Length;
	}


	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.
		if (agent.remainingDistance < 0.1f)
			GotoNextPoint();
	}
}