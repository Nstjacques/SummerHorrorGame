// Patrol.cs
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

/* Hi Nick! This script is for creating a really basic patrolling AI using the [Unity NavMesh](https://docs.unity3d.com/Manual/nav-BuildingNavMesh.html)
It takes an array of Transforms, aka the positions of objects in the scene, and then uses the NavMesh Agent component, which is to be applied to the object
you want to move on a patrol, and makes it find the next one! V simple, v useful. */

public class Patrol : MonoBehaviour {

	public Transform[] points;
	private int destPoint = 1;
	private NavMeshAgent agent;
	private bool playerInRange;
	private Vector3 playerTransform;

	public GameObject playerObject;

	private Ray raycast;

	private int lastPoint;

	private bool isInside;

	private Vector3 fromPosition;
	private Vector3 toPosition;
	private Vector3 direction;


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

		if (destPoint == 0) {
			destPoint += 1;
		}
	}


	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.
		playerTransform = playerObject.transform.position;

		if (agent.remainingDistance < 0.1f) {
			GotoNextPoint ();
		}

		if (playerInRange) {
			Vector3 fromPosition = this.transform.position;
			Vector3 toPosition = playerObject.transform.position;
			Vector3 direction = toPosition - fromPosition;

			RaycastHit hit = new RaycastHit ();

			if (Physics.Raycast (transform.position, direction, out hit)) {
				print ("sendingGoodVibes");
				if (hit.collider.gameObject.tag == "player") {
					print ("booming");

					lastPoint = destPoint;

					destPoint = 0;

					agent.destination = playerTransform;

					if (playerInRange == false) {
						destPoint = lastPoint;
						GotoNextPoint ();
					}
				} 

				if (hit.collider.gameObject.tag == "environment" || hit.collider.gameObject.tag == "door") {
					return;
				}
			}
		}
	}

	private void OnTriggerEnter(Collider other){
		playerInRange = (other.tag == "player");
	}

	private void OnTriggerExit(Collider other){
		playerInRange = (other.tag == "player");
	}
}