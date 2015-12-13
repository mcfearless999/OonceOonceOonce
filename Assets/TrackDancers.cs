using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrackDancers : MonoBehaviour {
	public GameObject[] dancers;
	CloseToYou[] scriptHolder;
	public Text text;
	public string nextLevel;
	// Use this for initialization
	void Start () {
		 dancers = GameObject.FindGameObjectsWithTag("Dancer");
		 scriptHolder = new CloseToYou[dancers.Length];
		for(int i = 0; i < dancers.Length; i++) {
			scriptHolder[i] = dancers[i].GetComponentInChildren<CloseToYou>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		int num_dancing = 0;
		int num_not_dancing = 0;
		foreach (CloseToYou s in scriptHolder) {
			if(s.dancing) {
				num_dancing++;
			} else {
				num_not_dancing++;
			}
		}
		text.text = "You have " + (float)num_dancing/(num_dancing+num_not_dancing) + " people dancing!";
		if(num_dancing == 0) {
			text.text = "Get all the people dancing!";
		} 
		if(num_not_dancing == 0) {
			text.text = "Everyone is dancing!  Yay!!!!";
		}
	}
}
