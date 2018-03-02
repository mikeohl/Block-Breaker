/* Paddle controls horizontal position of paddle to move with mouse location.
 * AutoPlay moves paddle with horizontal ball position for testing
 */

using UnityEngine;

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
	
    // Horizontal paddle position is aligned with horizontal mouse position
    void MoveWithMouse () {
        mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
        this.transform.position = paddlePos;
    }
	
    // Match horizontal paddle position with horizontal ball position
    void AutoPlay () {
        paddlePos.x = Mathf.Clamp(ball.transform.position.x, minX, maxX);
        this.transform.position = paddlePos;
    }
}
