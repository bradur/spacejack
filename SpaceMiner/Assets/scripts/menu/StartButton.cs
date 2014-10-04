using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour
{
		Color originalColor;
		public Color hoverColor;
		public Color activeColor;
		SpriteRenderer sr;
		// Use this for initialization
		void Start ()
		{
				sr = GetComponent<SpriteRenderer> ();
				originalColor = sr.color;
		}

		void OnMouseEnter ()
		{
				sr.color = hoverColor;
		}

		void OnMouseExit ()
		{
				sr.color = originalColor;
		}

		void OnMouseUp ()
		{
				sr.color = originalColor;
				Application.LoadLevel (1);
		}

		void OnMouseDown ()
		{
				sr.color = activeColor;
		}

		void OnMouseDrag ()
		{
				
		}
}
