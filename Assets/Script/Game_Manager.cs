using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//游戏的进行中的状态定义
public enum GameState
{
	Play,
	Pause,
	End,
}

public class Game_Manager : MonoBehaviour
{
	public GameState game_State;
	public int GameLv;
	public float GameSpeed;
	public Box_Loop box_Loop;
	public Scroll_Mapping s_Mapping;

	//在流动性的方法
	public float Meter = 0f;
	public int GetMoney = 0;


	//GUI 相关
	public Text Gold_Label;
	public Text Meter_Label;
	public Text result_Gold_Label;
	public Text result_Meter_Label;

	public RawImage PauseButton;
	public RawImage MainButton;
	public RawImage ReplayButton;
	public RawImage ContinueButton;
	public RawImage FinalImage;
	
	void Start ()
	{		
		GameSpeed = box_Loop.speed;		
		game_State = GameState.Play;
		hideButton ();
		FinalImage.gameObject.SetActive (false);
	}

	void Update ()
	{
		if (game_State == GameState.Play) {
			MeterUpdate ();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(game_State == GameState.Play){
				onPause();
			}else
				if(game_State == GameState.Pause){
					onContinue();
				}
		}

	}
	void hideButton(){
		PauseButton.gameObject.SetActive(true);
		MainButton.gameObject.SetActive(false);
		ReplayButton.gameObject.SetActive(false);
		ContinueButton.gameObject.SetActive(false);
	}

	void showButton(){
		PauseButton.gameObject.SetActive(false);
		MainButton.gameObject.SetActive(true);
		ReplayButton.gameObject.SetActive(true);
		ContinueButton.gameObject.SetActive(true);
	}
	public void onPause(){
		game_State = GameState.Pause;
		Time.timeScale = 0;
		showButton ();
	}

	public void onContinue(){
		hideButton ();
		Time.timeScale = 1;
		game_State = GameState.Play;
	}

	public void onReplay(){
		hideButton ();
		Time.timeScale = 1;
		Application.LoadLevel (1);
	}

	public void onMain(){
		hideButton ();
		Time.timeScale = 1;
		Application.LoadLevel (0);
	}

	public void GameOver ()
	{
		game_State = GameState.End;
		PauseButton.gameObject.SetActive (false);
		MainButton.gameObject.SetActive(true);
		ReplayButton.gameObject.SetActive(true);
		FinalImage.gameObject.SetActive (true);
		result_Gold_Label.text = string.Format ("{0:N0}", GetMoney);
		result_Meter_Label.text = string.Format ("{0:N0}<color=#ff3366> m</color>", Meter);
	}
	
	public void GetCoin ()
	{
		GetMoney += 1;
		Gold_Label.text = string.Format ("{0:N0}", GetMoney);
	}

	public void GetDiamond ()
	{
		GetMoney += 10;
		Gold_Label.text = string.Format ("{0:N0}", GetMoney);
	}

	
	public void MeterUpdate ()
	{
		Meter += Time.deltaTime * GameSpeed;
		Meter_Label.text = string.Format ("{0:N0}<color=#ff3366> m</color>", Meter);

		//时间流逝的速度越来越快。

		if (Meter >= 200 && GameLv == 1) {
			GameLevelUp ();
		}

		if (Meter >= 200 && GameLv == 2) {
			GameLevelUp ();
		}

		if (Meter >= 400 && GameLv == 3) {
			GameLevelUp ();
		}

		if (Meter >= 600 && GameLv == 4) {
			GameLevelUp ();
		}

		if (Meter >= 800 && GameLv == 5) {
			GameLevelUp ();
		}

		if (Meter >= 1000 && GameLv == 6) {
			GameLevelUp ();
		}
	}

	public void GameLevelUp ()
	{
		GameLv += 1;
		GameSpeed += 3;
		s_Mapping.ScrollSpeed += 0.1f;
		box_Loop.speed = GameSpeed;
	}
}