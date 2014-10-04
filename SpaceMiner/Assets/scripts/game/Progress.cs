using UnityEngine;
using System.Collections;

public class Progress : MonoBehaviour
{
		public float scaleStep;
		SpriteRenderer renderer;
		float defaultScale;

		void Start ()
		{
				defaultScale = transform.localScale.x;
				renderer = this.gameObject.GetComponent<SpriteRenderer> ();
				Hide ();
		}

		void Update ()
		{
		}

		public void ProgressOneStep ()
		{
				transform.localScale = new Vector3 (transform.localScale.x + scaleStep, transform.localScale.y, transform.localScale.z);
		}

		public void Hide ()
		{
				renderer.enabled = false;
		}

		public void Show ()
		{
				renderer.enabled = true;
		}

		public void SetScaleToDefault ()
		{
				transform.localScale = new Vector3 (defaultScale, transform.localScale.y, transform.localScale.z);
		}
}
