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
		float explosionTimer;
		public Animator asteroidAnimator;
		Pirate pirateScript;
		// Use this for initialization
		void Start ()
		{
				RotationStep = Random.Range (MinRotationStep, MaxRotationStep);
				int rotdir = Random.value > 0.5f ? 1 : -1;
				RotationStep = RotationStep * rotdir;
				eulerAngles = new Vector3 (0f, 0f, RotationStep);
				player = playerObject.GetComponent<Player> ();
		}

		public void DestroySelf ()
		{
				gameObject.tag = "Untagged";
				pirateScript.UpdateTravelingPoint ();
				Destroy (gameObject);
		}

        public void RestartPirateShip()
        {
            if (pirateScript == null)
            {
                pirateScript = GameObject.FindGameObjectWithTag("pirate").GetComponent<Pirate>();
            }
            EnableExplicitContent(pirateScript);
            pirateScript.StartMoving();
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

		//Enables animator
		public void EnableExplicitContent (Pirate pirateScript)
		{
				transform.rotation = Quaternion.identity;
				asteroidAnimator.enabled = true;
				this.pirateScript = pirateScript;
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
