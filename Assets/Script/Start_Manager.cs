using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Start_Manager : MonoBehaviour {

	public RawImage StartButton;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onStart(){
		Application.LoadLevel (1);
	}
}
