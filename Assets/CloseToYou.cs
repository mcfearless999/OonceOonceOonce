using UnityEngine;
using System.Collections;

public class CloseToYou : MonoBehaviour {

	public GameObject overHeadText;
	public TextMesh textMesh;
	public string startDanceText = "ZXZZ";

	int  textLeft;
	bool inTrigger;
	bool dancing;
	public Animator animator;

	// Use this for initialization
	void Start () {
		textMesh = overHeadText.GetComponentInChildren<TextMesh>();
		animator = this.GetComponentInChildren<Animator>();
		textMesh.text = startDanceText;
		textLeft = 0;
		dancing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(inTrigger && !dancing) {
			if(Input.GetKeyDown(KeyCode.Z)) {
				if(startDanceText[textLeft] == 'Z') {
					textLeft = textLeft + 1;
					redrawTextString();
				}
			}
			if(Input.GetKeyDown(KeyCode.X)) {
				if(startDanceText[textLeft] == 'X') {
					textLeft = textLeft + 1;
					redrawTextString();
				}
			}
			if(textLeft >= startDanceText.Length) {
				animator.enabled = true;
				dancing = true;
				// He's dancing now
			}

		}
	}
	void OnTriggerEnter2D(Collider2D c) {
		inTrigger = true;
		overHeadText.SetActive(true);
	}
	void OnTriggerExit2D(Collider2D c) {
		inTrigger = false;
		overHeadText.SetActive(false);
	}
	void redrawTextString() {
		textMesh.text = startDanceText.Substring(textLeft);
	}
}
