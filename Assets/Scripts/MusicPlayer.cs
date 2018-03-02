/* MusicPlayer makes sure that only on music player is 
 * instantiated across levels .
 */

using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;
	
	void Awake () {
		if (instance != null) { 
			Destroy (gameObject);
			// Debug.Log("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
