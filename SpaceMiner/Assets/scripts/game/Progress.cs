using UnityEngine;
using System.Collections;

public class Progress : MonoBehaviour
{
		public Transform progressSprite;
		public float scaleSpeed = 1f;
		Vector3 targetScale;
		Vector3 startScale;
		GameObject processTarget;
		public GameObject resourceManager;
		ResourceManager resources;
		bool isActive = false;
		int farmingSpeed;

		void Start ()
		{
				targetScale = progressSprite.localScale;  // target scale (max) is set in scene
				startScale = new Vector3 (0f, targetScale.y, targetScale.z);
				progressSprite.localScale = startScale;  // set scale to startscale (zero)
				gameObject.SetActive (false);             // disable

				resources = resourceManager.GetComponent<ResourceManager> ();
		}

		void Update ()
		{
				if (isActive) {

						resources.GiveMinerals (Mineral.Dmitryivanovite, 1);
						progressSprite.localScale = Vector3.MoveTowards (progressSprite.localScale, targetScale, Time.deltaTime * scaleSpeed);
						if (progressSprite.localScale == targetScale) {
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
