/* Ball class manages the position of the ball before launch and
 * gives random bounce velocity tweak on collision and 
 */

using UnityEngine;

public class Ball : MonoBehaviour {
	
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool gameHasStarted = false;

    // Use this for initialization
    void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
    void Update () {
        if (!gameHasStarted) {
            // Lock the ball relative to the paddle before launch
            this.transform.position = paddle.transform.position + paddleToBallVector;
		
            // Wait for a mouse press to launch
            if (Input.GetMouseButtonDown(0)) {
                gameHasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2.0f, 2.0f), 10.0f);
            }
        }
    }
	
	// Ball gets a random velocity tweak on collision and plays sound on collision
	void OnCollisionExit2D(Collision2D collision) {
        Vector2 tweak = new Vector2 (Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
        
        if (gameHasStarted) {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
