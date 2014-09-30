using UnityEngine;
using System.Collections;

public class MenuPlanet : MonoBehaviour {

	public float RotationStep = 0.2f;
    Vector3 eulerAngles;

    // Use this for initialization
	void Start () {
        eulerAngles = new Vector3(0f, 0f, RotationStep);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(eulerAngles);
	}
}
