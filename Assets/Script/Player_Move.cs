using UnityEngine;
using System.Collections;

public enum PlayerMoveStatus
{
	Run,
	Jump,
	DoubleJump,
	Die
};

public class Player_Move : MonoBehaviour
{
	
	public float Jump_Power;
	public PlayerMoveStatus status;
	public Player_Animation p_Animation = null;
	public Player_Sound p_Sound = null;

	void Start ()
	{
	
	}

	void Update ()
	{
		InputKeyboard ();
		Touch ();
		GetComponent<Rigidbody>().WakeUp ();
	}
	
	void Run ()
	{
		status = PlayerMoveStatus.Run;
		if (p_Animation != null)
			p_Animation.Run_Play ();
	}
	
	void Jump ()
	{
		
		status = PlayerMoveStatus.Jump;
		GetComponent<Rigidbody>().AddForce (0, Jump_Power * 1.5f, 0);

		
		if (p_Animation != null)
			p_Animation.Jump_Play ();

		if (p_Sound != null)
			p_Sound.SoundPlay (0);
		
	}
	
	void DoubleJump ()
	{
		
		status = PlayerMoveStatus.DoubleJump;
		GetComponent<Rigidbody>().AddForce (0, Jump_Power, 0);

		if (p_Animation != null)
			p_Animation.Double_Jump_Play ();

		if (p_Sound != null)
			p_Sound.SoundPlay (0);
	}
	
	void InputKeyboard()
	{
		if (Input.GetButtonDown ("Jump")) {

			if (status == PlayerMoveStatus.Jump) {
				DoubleJump ();
			}

			if (status == PlayerMoveStatus.Run) {
				Jump ();
			}
		}
	}

	//当该物体进入碰撞
	void OnCollisionEnter (Collision Get)
	{
		//状态不为空时，切换到运动状态
		if (status != PlayerMoveStatus.Die)
			Run ();


	}
	
	void Touch ()
	{
		if (Input.touchCount > 0) {                               
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				
				if (status == PlayerMoveStatus.Jump) {
					DoubleJump ();
				}
				
				if (status == PlayerMoveStatus.Run) {
					Jump ();
				}
			}
		}	
	}
	
	
}
