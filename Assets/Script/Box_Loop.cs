using UnityEngine;
using System.Collections;

public class Box_Loop : MonoBehaviour {
	
	//制作的地形预制体
	public GameObject[] boxs;
	//前面的地形模块
	public GameObject begin_Box;
	//前面的地形模块
	public GameObject middle_Box;
	//后面的地形模块
	public GameObject end_Box;
	
	//地形模块运行的速度
	public float speed = 3f;
	
	void Update () {
		Move();
	}
	
	//创造新的地形模块
	public void CreateNewBox(){
		
		begin_Box= middle_Box;
		middle_Box= end_Box;
		int boxNumber = Random.Range(0,boxs.Length-1);
		end_Box = Instantiate(boxs[boxNumber], new Vector3(60,0,0), transform.rotation) as GameObject;
		
	}
	
	//地形的移动
	public void Move(){
		
		begin_Box.transform.Translate(Vector3.left * speed *Time.deltaTime, Space.World);
		middle_Box.transform.Translate(Vector3.left * speed *Time.deltaTime, Space.World);
		end_Box.transform.Translate(Vector3.left * speed *Time.deltaTime, Space.World);
		
		if(middle_Box.transform.position.x<= -0f){
			Delete();
		}
	}
	
	//消除前面的地形模块
	public void Delete(){
		Destroy(begin_Box);
		CreateNewBox();
		
	}
}
