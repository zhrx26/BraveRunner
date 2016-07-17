using UnityEngine;
using System.Collections;

public class Player_Sound : MonoBehaviour {

	//音频数组，控制不同的声音
	public AudioClip[] soundArrs;

	public void SoundPlay(int soundNumber){
		GetComponent<AudioSource>().clip = soundArrs[soundNumber];
        GetComponent<AudioSource>().Play();
    }
	
}
