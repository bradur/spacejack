using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
		public float MaxRotationStep = 0.2f;
		public float MinRotationStep = 0.05f;
		float RotationStep;
		Vector3 eulerAngles;
		public GameObject playerObject;
		Player player;
		bool collided = false;
		public int mineralAmount;

		// Use this for initialization
		void Start ()
		{
				RotationStep = Random.Range (MinRotationStep, MaxRotationStep);
				int rotdir = Random.value > 0.5f ? 1 : -1;
				RotationStep = RotationStep * rotdir;
				eulerAngles = new Vector3 (0f, 0f, RotationStep);
				player = playerObject.GetComponent<Player> ();
				mineralAmount = (int)(transform.localScale.x * 1000);
		}

		public void DestroySelf ()
		{
				// animation ? 
				Destroy (gameObject);
		}

		// Update is called once per frame
		void Update ()
		{
				transform.Rotate (eulerAngles);
		}

		void OnMouseUp ()
		{
				player.MoveTo (transform.position);
		}

		void OnTriggerEnter2D (Collider2D col)
		{
				collided = true;
		}
}
