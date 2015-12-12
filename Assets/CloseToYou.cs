using UnityEngine;
using System.Collections;

public class CloseToYou : MonoBehaviour {

	public GameObject overHeadText;
	public TextMesh textMesh;
	public string startDanceText = "ZXZZ";

	int  textLeft;
	bool inTrigger;
	bool dancing;
	public float maxEnergy = 10f;
	public float energy;

	// Use this for initialization
	void Start () {
		textMesh = overHeadText.GetComponentInChildren<TextMesh>();
		textMesh.text = startDanceText;
		textLeft = 0;
		dancing = false;
		energy = maxEnergy;
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
		} else {
			if(dancing && inTrigger) {
				textMesh.text = energy.ToString("F1");
			}
			if(dancing && !inTrigger) {
				energy = energy - Time.deltaTime;
				if(energy <= 0f) {
					dancing = false;
					animator.enabled = false;
					textMesh.text = startDanceText;
					textLeft = 0;
					energy = maxEnergy;

				}
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
		if(!dancing) {
			textMesh.text = startDanceText.Substring(textLeft);
		} else {
			textMesh.text = energy.ToString("F1");
		}
	}
}
