using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

	public Transform tracker;

	private float cumulPitch;
	private float pitch0;
//	private float decroiss;

//	private const float tau = 1.0f;
	private const float sensibility = 1.0f;

//	private int n; 
//	private int pointer;

	// Use this for initialization
	void Awake () {

//		n = Mathf.RoundToInt (3.0f * tau / Time.fixedDeltaTime);
//		pointer = 0;

		pitch0 = tracker.localRotation.eulerAngles.x;
		cumulPitch = pitch0;

	}
	
	// Update is called once per frame

	void FixedUpdate () {

		cumulPitch *= 0.99f;
		cumulPitch += tracker.localRotation.eulerAngles.x * Time.fixedDeltaTime; // A voir

		transform.RotateAround (transform.position, transform.right, sensibility * cumulPitch);
	
	}
}
