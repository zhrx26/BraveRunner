using UnityEngine;
using System.Collections;

public class Camera_Zoom : MonoBehaviour
{

	public Camera _camera;
	public GameObject _player;
	public float speed;
	public float MaxSize = 10f;
	public float MinSize = 5f;
	float CameraSize = 8f;
	
	void Start(){
	
	}
	
	
	void Update ()
	{
		
		if (_player != null)
			CameraSize = 8f + _player.transform.position.y;
			
		if (CameraSize >= MaxSize) {
			CameraSize = MaxSize;
		}
			
		if (CameraSize <= MinSize) {
			CameraSize = MinSize;
		}
			
			
		//单纯的相机值改变的情况。
		//_camera.orthographicSize = 4.5f+_player.transform.position.y;
			
		//相机值平滑改变的情况。
			
		_camera.orthographicSize = Mathf.Lerp (_camera.orthographicSize, CameraSize, Time.deltaTime / speed);
		
	}
}
