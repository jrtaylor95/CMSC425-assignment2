using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject granny;
	private int grannyCount;
	private float pulse;
	// Use this for initialization
	void Start () {
		grannyCount = 0;
		pulse = Time.time + 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > pulse) {
			if (grannyCount >= 1)
				pulse = Time.time + 5;
			else
				pulse = Time.time + 3;
			
			if (grannyCount != 3) {
				if (grannyCount == 0) {
					Instantiate (granny, Vector3.zero, Quaternion.identity);
				} else if (grannyCount % 2 == 0) {
					Instantiate (granny, Vector3.left, Quaternion.identity);
				} else {
					Instantiate (granny, Vector3.right, Quaternion.identity);
				}
				grannyCount++;
			}
		}
	}
}
