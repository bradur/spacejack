using UnityEngine;
using System.Collections;

public class BorderManager : MonoBehaviour
{

		public float leftBorder;
		public float rightBorder;
		public float upBorder;
		public float downBorder;
		public GameObject up;
		public GameObject down;
		public GameObject left;
		public GameObject right;

		void Start ()
		{
				leftBorder = left.transform.position.x;
				rightBorder = right.transform.position.x;
				upBorder = up.transform.position.y;
				downBorder = down.transform.position.y;
		}
}
