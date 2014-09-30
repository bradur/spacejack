using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
		public GameObject player;
		Player p;
		// Use this for initialization
		void Start ()
		{

				p = player.GetComponent<Player> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		void OnMouseDrag ()
		{
				p.MoveTo (transform.position);
		}

}
