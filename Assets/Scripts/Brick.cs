using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	static public int breakableCount = 0;

	public Sprite[] hitSprites;
	public AudioClip crack;
	public GameObject smoke;
	public float volume;
	
	private int maxHits;
	private int timesHit;
	private bool isBreakable;
	private LevelManager levelManager;

	void OnCollisionExit2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack, transform.position, volume);
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits () {
		timesHit++;
		
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
			Debug.Log ("Breakables left: " + breakableCount);
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
		
		Debug.Log ("Brick Hit!");
	}
	
	void PuffSmoke () {
		GameObject smokePuff = Instantiate (smoke, this.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Failed to Load Brick Sprite");
		}
	}

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		maxHits = hitSprites.Length + 1;
		smoke.transform.position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	// TODO Remove this method once we can actually win!
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
