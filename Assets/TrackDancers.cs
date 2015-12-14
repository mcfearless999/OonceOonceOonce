using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrackDancers : MonoBehaviour {
	public GameObject[] dancers;
	CloseToYou[] scriptHolder;
	public Text text;
	public string nextLevel;
	public Text	endingtext;
	public float timedelay;
	public int win;
	bool particleWinFlag;

	// Use this for initialization
	void Start () {
		particleWinFlag = false;
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
			if(win == 1) {
				s.energy = s.maxEnergy;
				s.dancing = true;
			}
			if(s.dancing) {
				num_dancing++;
			} else {
				num_not_dancing++;
			}
		}
		text.text = "You have " + ((float)num_dancing/(num_dancing+num_not_dancing)*100).ToString("F2") + "% people dancing!";
		if(num_dancing == 0) {
			text.text = "Get all the people dancing!";
		} 
		if(num_not_dancing == 0 || win==1) {
			if(!particleWinFlag) {
				foreach (CloseToYou s in scriptHolder) {
					s.yayWin();
				}
			}
			win = 1;
			text.text = "Everyone is dancing!  Yay!!!!";
			timedelay = timedelay - Time.deltaTime;
			endingtext.text = "YOU ARE AWESOME !!!!!!" +
				"Next Level";
			if (timedelay <= 0) {
				

				UnityEngine.SceneManagement.SceneManager.LoadScene (nextLevel);
			}

		}
	}
}
