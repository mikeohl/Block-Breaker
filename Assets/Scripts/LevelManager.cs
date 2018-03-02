/* LevelManager is responsible for loading the 
 * next scene and quiting the application.
 * Uses Unity Scene Management for loading scenes. 
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel (string name) {
		Debug.Log ("Level load requested for: " + name);
		Brick.breakableCount = 0;
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

    public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest () {
		Debug.Log ("Player wants to quit");
		Application.Quit();
	}
	
    // Called everytime brick is destroyed. Next level loaded
    // when no bricks are left
	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
}
