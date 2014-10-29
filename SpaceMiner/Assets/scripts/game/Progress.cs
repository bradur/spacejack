using UnityEngine;
using System.Collections;

public class Progress : MonoBehaviour
{
		public Transform progressSprite;
		public float scaleSpeed = 1f;
		Vector3 targetScale;
		Vector3 startScale;
		GameObject processTarget;
		bool isActive = false;
		int farmingSpeed;
		public HudManager hudManager;

		void Start ()
		{
				targetScale = progressSprite.localScale;  // target scale (max) is set in scene
				startScale = new Vector3 (0f, targetScale.y, targetScale.z);
				progressSprite.localScale = startScale;  // set scale to startscale (zero)
				gameObject.SetActive (false);             // disable
		}

		void Update ()
		{
				if (isActive) {						
						progressSprite.localScale = Vector3.MoveTowards (progressSprite.localScale, targetScale, (Time.deltaTime * scaleSpeed) / (processTarget.GetComponent<Asteroid> ().mineralAmount / 10));
						if (progressSprite.localScale == targetScale) {
								hudManager.UpdateResources (processTarget.GetComponent<Asteroid> ().MineralType, processTarget.GetComponent<Asteroid> ().MineralAmount);
								Finish ();
						}
				}
		}

		public void SetTarget (GameObject targetObject)
		{
				processTarget = targetObject;
		}

		public void StartProcess (int farmingSpeed)
		{
				isActive = true;
				gameObject.SetActive (true);
				scaleSpeed = farmingSpeed;
		}

		void Finish ()
		{
				if (processTarget != null) {
						processTarget.GetComponent<Asteroid> ().DestroySelf ();
						processTarget = null;
				}
				EndProcess ();
		}

		public void EndProcess ()
		{
				isActive = false;
				gameObject.SetActive (false);
				progressSprite.localScale = startScale;
		}

}
