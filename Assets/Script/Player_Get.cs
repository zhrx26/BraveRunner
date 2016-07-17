using UnityEngine;
using System.Collections;

public class Player_Get : MonoBehaviour
{
	
	public Player_Sound p_Sound;
	public Player_Move p_Move;
	public int Get_Coin_Count = 0;
	public Game_Manager g_Manager;

	void Start(){
		
	}
	
	void OnTriggerEnter (Collider Get)
	{
       
		if (Get.tag == "Enemy") {
			if (p_Move.status != PlayerMoveStatus.Die) {
				p_Move.status = PlayerMoveStatus.Die;

				//Get.gameObject.GetComponent<Animation> ().PlayQueued("hit2");
				


				if (p_Sound != null){
					p_Sound.SoundPlay (2);
					Debug.Log("p_sound true");
				}

				if (g_Manager != null)
					g_Manager.GameOver ();

			//	gameObject.SetActive(false);

				Destroy(gameObject);
				

				

			}


		}

		if (Get.tag == "coin") {
			Get.gameObject.SetActive (false);
			Get_Coin_Count += 1;
			if(g_Manager != null)
				g_Manager.GetCoin();
			if (p_Sound != null && p_Move.status != PlayerMoveStatus.Die)
				p_Sound.SoundPlay (1);
		}

		if (Get.tag == "Diamond") {	
			Get.gameObject.SetActive (false);
			Get_Coin_Count += 10;
			if(g_Manager != null)
				g_Manager.GetDiamond();
			if (p_Sound != null)
				p_Sound.SoundPlay (1);
		}
		
		if (Get.tag == "DeathZone") {
			if (p_Move.status != PlayerMoveStatus.Die) {
				p_Move.status = PlayerMoveStatus.Die;
				this.gameObject.GetComponent<Rigidbody>().AddForce (0, -50f, 0);
				if (g_Manager != null)
					g_Manager.GameOver ();
				
				if (p_Sound != null)
					p_Sound.SoundPlay (2);
			}
			
		}


	}


}
