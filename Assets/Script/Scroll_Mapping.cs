using UnityEngine;
using System.Collections;

public class Scroll_Mapping : MonoBehaviour
{
	
	public float ScrollSpeed = 0.2f;
	float Offset;

	//控制背景的主纹理偏移值
	void Update ()
	{
	
		Offset += Time.deltaTime * ScrollSpeed;
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (Offset, 0.01f);
		
	}
}



