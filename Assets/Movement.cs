using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public int upright;
	public int downright;
	public char ismoving;
	public float speed = 0.1f;
	public float maxvertical;
	public float maxhorizontal;
	public float minvertical; 
	public float minhorizontal;

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

		if (ismoving == 'z') {
			p = new Vector3 (p.x + speed * upright, p.y + speed * upright, p.z);
		}		
		if (ismoving == 'x') {
			p = new Vector3 (p.x - speed * downright, p.y + speed * downright, p.z);
		}


		if (p.x > maxhorizontal) {
			p = new Vector3 (maxhorizontal, p.y, p.z);
		}
		if (p.x < minhorizontal) {
			p = new Vector3 (minhorizontal, p.y, p.z);
		}
		if (p.y > maxvertical) {
			p = new Vector3 (p.x, maxvertical, p.z);
		}
		if (p.y < minvertical){
			p = new Vector3 (p.x, minvertical, p.z);
		}
		transform.position = p;
	}
}