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

	Animator myAnimator;
	Vector3 oldLocation;
	Vector3 olderLocation;

	//restricted area check
	//public float CheckRestricted(float x1, float x2, float y1, float y2){
	//	int Restx = 0;
	//	int Resty = 0;

	//}


	// Use this for initialization
	void Start () {
		myAnimator = this.GetComponentInChildren<Animator>();
		upright		= 1;
		downright 	= 1;

	}

	public int CheckWall1(float xvect, float yvect){
		if (xvect < -2.9f && yvect < -0.3f) {
			return 1;
		} else { 
			return 0;
		}
	}
	public int CheckWall2(float xvect, float yvect){
			if (xvect > 1.8f && yvect < -2.5f) {
				return 1;
			} else { 
				return 0;
			}

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
			myAnimator.CrossFade("standing", 0f);
		}
		if(Input.GetKeyUp(KeyCode.X)) {
			ismoving = ' ';
			downright = downright * -1;
			myAnimator.CrossFade("standing", 0f);
		}		
	}

	void FixedUpdate () {
		Vector3 p = transform.position;

//			olderLocation = oldLocation;
//			oldLocation = p;
//		}
		if (ismoving == 'z') {
			p = new Vector3 (p.x + speed * upright, p.y + speed * upright, p.z);
			if(upright == 1) {
				myAnimator.CrossFade("right", 0f);
			} else {
				myAnimator.CrossFade("left", 0f);

			}
		} 
		if (ismoving == 'x') {
			p = new Vector3 (p.x - speed * downright, p.y + speed * downright, p.z);
			if(downright == 1) {
				myAnimator.CrossFade("left", 0f);
			} else {
				myAnimator.CrossFade("right", 0f);
			}
		}

		int wallcheck1 = CheckWall1 (p.x, p.y);
		int wallcheck2 = CheckWall2 (p.x, p.y);
		if (wallcheck1 == 1 || wallcheck2 ==1) {
			p = transform.position;
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
	void OnTriggerEnter2D(Collider2D c) {
		if(c.tag == "Wall") {
			upright = upright * - 1;
			downright = downright * -1;
//			Debug.Log("Wall");

//			olderLocation = transform.position;
		}
	}
	void OnTriggerStay2D(Collider2D c) {
		//Debug.Log("Collider");
		if(c.tag == "Wall") {

//			Debug.Log("In Wall");
//			transform.position = olderLocation;
		}
	}
	void OnTriggerExit2D(Collider2D c) {
		//Debug.Log("Collider");
		if(c.tag == "Wall") {

		}
	}
}