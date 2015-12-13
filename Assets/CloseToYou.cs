using UnityEngine;
using System.Collections;

public class CloseToYou : MonoBehaviour {

	public GameObject overHeadText;
	public TextMesh textMesh;

	public SpriteRenderer myRenderer;
	public Material dancingSpriteMaterial;
	public Material notDancingSpriteMaterial;

	Animator animator;
	public string startDanceText = "ZXZZ";

	int  textLeft;
	bool inTrigger;
	bool dancing;
	public float maxEnergy = 10f;
	public float energy;
	float lastColorChangeTime;

	// Use this for initialization
	void Start () {
		animator = this.GetComponentInChildren<Animator>();
		textMesh = overHeadText.GetComponentInChildren<TextMesh>();
		textMesh.text = startDanceText;
		textLeft = 0;
		dancing = false;
		energy = maxEnergy;

		myRenderer = this.GetComponentInChildren<SpriteRenderer>();
		notDancingSpriteMaterial = myRenderer.material;
		dancingSpriteMaterial = Resources.Load<Material>("shiny");
		if(dancingSpriteMaterial == null) {
			Debug.Log("shiny material not loaded");
			dancingSpriteMaterial = myRenderer.material;
		}
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
				myRenderer.material = dancingSpriteMaterial;
				lastColorChangeTime = Time.time;
				// He's dancing now

			} 
		} else {
			if(dancing) {
					changeColor();
					if(dancing && inTrigger) {
					textMesh.text = energy.ToString("F1");
					if(energy< maxEnergy) {
						energy = energy+Time.deltaTime;
						if(energy > 10f) {
							energy = 10f;
						}
					}
				}
				if(dancing && !inTrigger) {
					energy = energy - Time.deltaTime;
					if(energy <= 0f) {
						dancing = false;
						animator.enabled = false;
						textMesh.text = startDanceText;
						textLeft = 0;
						energy = maxEnergy;
						myRenderer.material = notDancingSpriteMaterial;

					}
				}
			}
		}
	}

	void changeColor() {
		if((Time.time - lastColorChangeTime) > (.5f / energy)) {
			myRenderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
			lastColorChangeTime = Time.time;
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
