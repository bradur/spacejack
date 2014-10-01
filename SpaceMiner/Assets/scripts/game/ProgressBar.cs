using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
	float progress = 0;
	Vector2 pos = new Vector2 (20, 40);
	Vector2 size = new Vector2 (60, 20);
	Texture2D progressBarEmpty;
	Texture2D progressBarFull;
	
	void Update ()
	{

		//GUI.DrawTexture (Rect (pos.x, pos.y, size.x, size.y), progressBarEmpty);
		//GUI.BeginGroup (new Rect (pos.x, pos.y, size.x * Mathf.Clamp01 (progress), size.y));
		//GUI.DrawTexture (new Rect (0, 0, size.x, size.y), progressBarFull);
		//GUI.EndGroup ();
		//progress = Time.time * 0.05f;
	}

	void OnGUI ()
	{
		// Make a background box
		GUI.Box (new Rect (10, 10, 100, 100), "Progress");


	}
}
