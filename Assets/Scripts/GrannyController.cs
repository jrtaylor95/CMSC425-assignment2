using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GrannyController : MonoBehaviour {

	private static int granniesLeft = 3;
	private Rigidbody rb;
	private Animator animator;
	private GameObject bigVegas;
	private Vector3 grannyVel;
	private bool isFallen;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		bigVegas = GameObject.Find ("Player");
		animator = GetComponent<Animator> ();
		grannyVel = Vector3.zero;
		isFallen = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (granniesLeft);
		Vector3 toBigVegas;

		Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);
		RaycastHit hit;
		bool isGrounded = Physics.Raycast (ray, out hit);

		if (isGrounded) {
			if (Vector3.Distance(transform.position, bigVegas.transform.position) < 5) {
				toBigVegas = bigVegas.transform.position - transform.position;
				toBigVegas.y = 0;

				Vector3 attraction = toBigVegas * .01f;
				grannyVel = Vector3.ClampMagnitude (grannyVel + attraction, 3);
				rb.MovePosition (transform.position + (grannyVel * Time.deltaTime));
				transform.rotation = Quaternion.LookRotation (toBigVegas);
			} else {
				grannyVel = Vector3.zero;
			}
			animator.SetFloat ("vel", grannyVel.magnitude);
		} else {
			if (!isFallen) {
				isFallen = true;
				granniesLeft--;
				if (granniesLeft == 0) {
					loadWinScene ();
				}
			}
			//Give the granny one final push off the edge
			rb.MovePosition (transform.position + (grannyVel * Time.deltaTime));
			animator.SetBool ("grounded", false);
			Destroy (gameObject, 5);
		}
	}

	void loadWinScene() {
		SceneManager.LoadScene (2);
	}
}
