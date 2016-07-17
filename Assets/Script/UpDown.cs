using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour
{
	
	public float speed = 0.5f;
	public float ChangeTime = 0f;
	float timeSum = 0f;
	public bool isUp = true;
	public float up_Position = 3f;
	public float down_Position = 0f;
	
	void Start ()
	{
		//最高上升高度
		up_Position = transform.position.y + up_Position;
		//最低下降高度
		down_Position = transform.position.y;
	}
	
	void Update ()
	{
		//记录运行时间
		timeSum += Time.deltaTime;
		//判断是否在上升或者下降
		if (isUp == true) {
			transform.position = new Vector3 (transform.position.x, Mathf.Lerp (transform.position.y, up_Position, Time.deltaTime / speed), transform.position.z);
			if (timeSum >= speed) {
				timeSum = 0;
				isUp = false;
			}
		} else {
			transform.position = new Vector3 (transform.position.x, Mathf.Lerp (transform.position.y, down_Position, Time.deltaTime / speed), transform.position.z);
			if (timeSum >= speed) {
				timeSum = 0;
				isUp = true;
			}
			
		}
		
	}
}
