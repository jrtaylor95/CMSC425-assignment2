using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MotionAgent : MonoBehaviour {

	private NavMeshAgent agent;
	private Animator animator;
	Vector2 smoothDeltaPos = Vector2.zero;
	Vector2 velocity = Vector2.zero;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.updatePosition = false;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 worldDeltaPos = agent.nextPosition - transform.position;

		float dx = Vector3.Dot (transform.right, worldDeltaPos);
		float dy = Vector3.Dot (transform.forward, worldDeltaPos);
		Vector2 deltaPos = new Vector2 (dx, dy);

		float smooth = Mathf.Min (1.0f, Time.deltaTime / 0.15f);
		smoothDeltaPos = Vector2.Lerp (smoothDeltaPos, deltaPos, smooth);

		if (Time.deltaTime > 1e-5f)
			velocity = smoothDeltaPos / Time.deltaTime;

		bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

		animator.SetBool ("move", shouldMove);
		animator.SetFloat ("velx", velocity.x);
		animator.SetFloat ("vely", velocity.y);
	}

	void onAnimatorMove() {
		transform.position = agent.nextPosition;
	}
}
