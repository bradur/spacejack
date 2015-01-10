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
		public Resource mineralType;
		bool bombPlanted;
		float explosionTimer;
		GameObject asteroidExplosion;
		// Use this for initialization
		void Start ()
		{
				bombPlanted = false;
				RotationStep = Random.Range (MinRotationStep, MaxRotationStep);
				int rotdir = Random.value > 0.5f ? 1 : -1;
				RotationStep = RotationStep * rotdir;
				eulerAngles = new Vector3 (0f, 0f, RotationStep);
				player = playerObject.GetComponent<Player> ();
		}

		public void DestroySelf ()
		{
				asteroidExplosion.GetComponent<Explosion> ().Explode (transform.position.x, transform.position.y);
				Destroy (gameObject);
		}

		// Update is called once per frame
		void Update ()
		{
				transform.Rotate (eulerAngles);
				if (bombPlanted) {
						explosionTimer -= Time.deltaTime;
						if (explosionTimer < 0) {
								DestroySelf ();
						}
				}
		}

		void OnMouseUp ()
		{
				player.MoveTo (transform.position);
		}

		void OnTriggerEnter2D (Collider2D col)
		{
				collided = true;
		}

		public void SetAsteroidExplosion (GameObject asteroidAnim)
		{
				this.asteroidExplosion = asteroidAnim;
		}

		public GameObject GetAsteroidExplosion ()
		{
				return asteroidExplosion;
		}

		public void ExplodeInSeconds (float seconds)
		{
				if (!bombPlanted) {
						bombPlanted = true;
						explosionTimer = seconds;
				}
		}

		public Resource MineralType {
				get { return this.mineralType;}
				set { this.mineralType = value;}
		}

		public int MineralAmount {
				get{ return this.mineralAmount;}
				set{ this.mineralAmount = value;}
		}
}
