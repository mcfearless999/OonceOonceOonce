using UnityEngine;
using System.Collections;

public class CloseToYou : MonoBehaviour {

	public GameObject overHeadText;
	public TextMesh textMesh;

	public SpriteRenderer myRenderer;
//	public Sprite mySprite;
	public Material dancingSpriteMaterial;
	public Material notDancingSpriteMaterial;

//	public Sprite dancingSprite;
//	public Sprite notDancingSprite;

	public Animator myAnimator;
//	public Animator dancingAnimator;
//	public Animator notDancingAnimator;

	public string startDanceText = "ZXZZ";

	int  textLeft;
	bool inTrigger;
	bool dancing;
	public float maxEnergy = 10f;
	public float energy;
	float lastColorChangeTime;

	// Use this for initialization
	void Start () {
		myAnimator = this.GetComponentInChildren<Animator>();
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
	//	mySprite = myRenderer.sprite;
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
				//animator.enabled = true;
		//		myRenderer.sprite = dancingSprite;
				//myAnimator = dancingAnimator;
				dancing = true;
				myRenderer.material = dancingSpriteMaterial;
				lastColorChangeTime = Time.time;
				// He's dancing now
	//			mySprite = myRenderer.sprite; //debug;
				myAnimator.CrossFade("Dancing", 0f);

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
						//animator.enabled = false;
			//			myRenderer.sprite = notDancingSprite;
						//myAnimator = notDancingAnimator;
						textMesh.text = startDanceText;
						textLeft = 0;
						energy = maxEnergy;
						myRenderer.material = notDancingSpriteMaterial;
			//			mySprite = myRenderer.sprite; //debug;
						myAnimator.CrossFade("Not Dancing", 0f);
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
