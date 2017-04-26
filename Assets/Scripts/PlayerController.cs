using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;

			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100)) {
				agent.destination = hit.point;
			}
		}
			
		float velocity = agent.velocity.magnitude;
		animator.SetFloat ("vel", velocity);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Granny")) {
			SceneManager.LoadScene (3);
		}
	}
}
