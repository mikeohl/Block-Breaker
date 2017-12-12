using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	
	void OnTriggerEnter2D (Collider2D trigger) {
		Debug.Log ("Trigger");
		levelManager.LoadLevel("Lose Screen");
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		Debug.Log ("Collision");
	}

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
