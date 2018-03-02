/* Brick class manages game bricks. Bricks play audio, change sprite
 * display on collision. Smoke particle generated and brick object
 * destroyed when brick reaches maximum hits.
 */

using UnityEngine;

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

    // Use this for initialization
    void Start() {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = (this.tag == "Breakable");
        if (isBreakable) {
            breakableCount++;
        }
        timesHit = 0;
        maxHits = hitSprites.Length + 1;
        smoke.transform.position = this.transform.position;
    }

    // Play hit sound and handle hits on collision
    void OnCollisionExit2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack, transform.position, volume);
		if (isBreakable) {
			HandleHits();
		}
	}
	
    // Increase timesHit and update sprite or destroy brick on hit
	void HandleHits () {
		timesHit++;
		
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Failed to Load Brick Sprite");
		}
	}

    void PuffSmoke() {
        GameObject smokePuff = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
        var main = smokePuff.GetComponent<ParticleSystem>().main;
        main.startColor = this.GetComponent<SpriteRenderer>().color;
    }
}
