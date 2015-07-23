using UnityEngine;
using System.Collections;

public class BattementAiles : MonoBehaviour {

	public Transform tracker;
	public Transform aileDroite;
	public Transform aileGauche;

	private Vector3 pos0Droite;
	private Vector3 pos0Gauche;
	private float rayon;

	void Awake () {
		Vector3 dist = GetComponent<Transform> ().position - aileDroite.position;
		rayon = Mathf.Abs (dist.magnitude);
		pos0Droite = aileDroite.localPosition;
		pos0Gauche = aileGauche.localPosition;

	}
	
	// Update is called once per frame
	void Update () {
		float theta = Mathf.Clamp( 2.0f * tracker.localRotation.eulerAngles.x, -80.0f, 80.0f ) ;
		float _sin = Mathf.Sin ( Mathf.PI * theta / 180f );
		float _cos = Mathf.Cos ( Mathf.PI * theta / 180f );

		aileDroite.localRotation = Quaternion.Euler( 0f, 0f, 90f - theta );
		aileDroite.localPosition = pos0Droite + new Vector3 ( -rayon * (1f - _cos), - rayon * _sin, 0f );

		aileGauche.localRotation = Quaternion.Euler( 0f, 0f, 90f + theta );
		aileGauche.localPosition = pos0Gauche + new Vector3 ( rayon * (1f - _cos), - rayon * _sin, 0f );
	}
}
