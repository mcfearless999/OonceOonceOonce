using UnityEngine;
using System.Collections;


public class StartGame : MonoBehaviour {
	public string Scene;
	// Use this for initialization
	public void  LevelStart(){
		Application.LoadLevel (Scene);
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
