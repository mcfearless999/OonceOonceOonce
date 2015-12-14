using UnityEngine;
using System.Collections;


public class ReturnToTitle : MonoBehaviour {
	public string Scene = "Opening";
	// Use this for initialization
	public void  GoToTitle(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(Scene);
	}
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}