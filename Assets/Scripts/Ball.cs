using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		// Debug.Log(paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
		
			// Wait for a mouse press to launch.
			if (Input.GetMouseButtonDown(0)) {
				Debug.Log("Mouse Clicked, Launch Ball!");
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2(Random.Range(-2.0f, 2.0f), 10.0f);
			}
		}
	}
	
	// Play sound on collision
	void OnCollisionExit2D(Collision2D collision) {
		// Random ball bounce vector
		Vector2 tweak = new Vector2 (Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
		
		if (hasStarted) {
			audio.Play();
			rigidbody2D.velocity += tweak;
		}
	}
}
