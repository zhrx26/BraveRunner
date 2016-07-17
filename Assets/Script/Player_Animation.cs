using UnityEngine;
using System.Collections;

public class Player_Animation : MonoBehaviour {


	public float Ani_Play_Speed;
	float Ani_Play_Time;
	public bool _run;
	public bool _jump;
	public bool _d_jump;

	void Start () {
		Run_Play ();
	}

	void Update () {

	}

	public void Run_Play ()
	{
		
		_run = true;
		_jump = false;
		_d_jump = false;
		GetComponent<Animator> ().SetBool ("isRun" , false);
		GetComponent<Animator> ().SetBool ("isJump" , false);
	}
		
	public void Jump_Play ()
	{
		
		_run = false;
		_jump = true;
		_d_jump = false;
		GetComponent<Animator> ().SetBool ("isRun" , true);
		GetComponent<Animator> ().SetBool ("isJump" , false);
	}
		
	public void Double_Jump_Play ()
	{
		
		_run = false;
		_jump = false;
		_d_jump = true;
		GetComponent<Animator> ().SetBool ("isJump" , true);
		
	}
}
