using UnityEngine;
using System.Collections;

public class ExplosionNumber : MonoBehaviour {

	public float timer;
	bool countingStarted;

	// Use this for initialization
	void Start () {
//		this.GetComponent<Animator>().
		this.GetComponent<Animator>().speed = 1/12f;
//		Debug.Log(this.GetComponent<Animator>().speed);
		
		countingStarted = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(countingStarted){
			timer -= Time.deltaTime;
			if(timer > 2){

			}
			else if(timer > 1 && timer < 2){

			}
			else if(timer < 1){

			}
		}
	}

	public void StartCounting(){
		countingStarted = true;
	}
}
