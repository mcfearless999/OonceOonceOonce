using UnityEngine;
using System.Collections;


public class StartGame : MonoBehaviour {
	public string Scene;
	// Use this for initialization
	public void  LevelStart(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(Scene);
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
