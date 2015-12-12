using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public int upright;
	public int downright;
	public char ismoving;
	public float speed = 0.1f;
	// Use this for initialization
	void Start () {
		upright		= 1;
		downright 	= 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Z)) {
			ismoving = 'z';
		}
		if(Input.GetKeyDown(KeyCode.X)) {
			ismoving = 'x';
		}
		if(Input.GetKeyUp(KeyCode.Z)) {
			ismoving = ' ';
			upright = upright * - 1;
		}
		if(Input.GetKeyUp(KeyCode.X)) {
			ismoving = ' ';
			downright = downright * -1;
		}		
	}

	void FixedUpdate () {
		Vector3 p = transform.position;
		if(ismoving == 'z') {
			p = new Vector3(p.x + speed * upright, p.y + speed * upright, p.z);
		}		
		if(ismoving == 'x') {
			p = new Vector3(p.x - speed * downright, p.y + speed * downright, p.z);
		}
		transform.position = p;

	}
}
