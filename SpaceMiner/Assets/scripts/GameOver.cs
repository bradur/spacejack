using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public int levelToLoad;

	void OnMouseDown(){
		Application.LoadLevel(levelToLoad);
	}
}
