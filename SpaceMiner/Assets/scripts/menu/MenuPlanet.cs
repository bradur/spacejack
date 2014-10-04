using UnityEngine;
using System.Collections;

public class MenuPlanet : MonoBehaviour {

	public float RotationStep = 0.2f;
    Vector3 eulerAngles;

    public float BounceInterval = 5.0f;
    public float BounceFactor = 1.5f;
    public float BounceStep = 0.01f;

    public float BounceStart = 5.0f;
    public float BounceSpeed = 2.5f;

    float bounceTimer;
    float startBounceTimer;

    Vector3 bounceMax;
    Vector3 originalScale;
    Vector3 bounceScale;
    Vector3 currentTargetScale;

    bool bouncingUp = true;

    float startTime;

    // Use this for initialization
	void Start () {
        eulerAngles = new Vector3(0f, 0f, RotationStep);
        bounceTimer = BounceInterval;
        bounceScale = transform.localScale;
        originalScale = transform.localScale;
        startBounceTimer = BounceStart;
        bounceMax = new Vector3(transform.localScale.x*BounceFactor, transform.localScale.y*BounceFactor, transform.localScale.z);
        currentTargetScale = bounceMax;
	}
	
	// Update is called once per frame
	void Update () {
        bounceTimer -= Time.deltaTime;
        startBounceTimer -= Time.deltaTime;

        if(startBounceTimer < 0f){
            if(bounceTimer < 0f){
                if(startTime == 0f){
                    //print("Bouncing to: "+currentTargetScale);
                    startTime = Time.time-0.1f;
                }
                float distCovered = (Time.time - startTime) * BounceSpeed;
                float fracJourney = distCovered;// / journeyLength;
                transform.localScale = Vector3.Lerp(transform.localScale, currentTargetScale, fracJourney);
                if(transform.localScale == currentTargetScale){
                    startTime = 0f;
                    currentTargetScale = originalScale;
                }

                // if we have finished bouncing up and down
                if(transform.localScale == originalScale){
                    //print("----- finished both! -----");
                    bounceTimer = BounceInterval;
                    currentTargetScale = bounceMax;
                }
            }
        }

        transform.Rotate(eulerAngles);
	}

    void Bounce(){

    }


}
