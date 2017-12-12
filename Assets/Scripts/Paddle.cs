using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX, maxX;
	
	private Vector3 paddlePos; 
	private float mousePosInBlocks;
	private Ball ball;
	
	// Use this for initialization
	void Start () {
		paddlePos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse () {
		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay () {
		paddlePos.x = Mathf.Clamp(ball.transform.position.x, minX, maxX);
		this.transform.position = paddlePos;
	}
}
