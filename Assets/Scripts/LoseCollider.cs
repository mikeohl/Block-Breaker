/* LoseCollider loads lose screen on entering trigger volume*/

using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

    // Use this for initialization
    void Start() {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Load Lose Screen on trigger enter
    void OnTriggerEnter2D (Collider2D trigger) {
		levelManager.LoadLevel("Lose Screen");
	}
}
