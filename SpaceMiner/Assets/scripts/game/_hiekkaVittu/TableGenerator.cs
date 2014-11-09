using UnityEngine;
using System.Collections;

public class TableGenerator : MonoBehaviour
{

//		public Transform element;
		Object elementTemplate;
		GameObject tableElement;
		public int rows;
		public int columns;

		

		

		// Use this for initialization
		void Start ()
		{
				elementTemplate = Resources.Load ("table_element");
				
				GenerateTable ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void GenerateTable ()
		{
				float original_x = transform.position.x;
				float x = transform.position.x;
				float y = transform.position.y;
				for (int i = 0; i < rows; i++) {
						for (int j = 0; j < columns; j++) {
								GenerateElement (x, y);
								x += 0.35f;
						}
						//how do I count image width/height in here?
						y -= 0.35f;
						x = original_x;
				}
		}

		void GenerateElement (float x, float y)
		{
				tableElement = (GameObject)Instantiate (elementTemplate);
				tableElement.transform.parent = transform;
				tableElement.transform.localPosition = new Vector3 (x, y, 0);
		}
}
