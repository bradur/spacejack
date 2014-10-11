using UnityEngine;
using System.Collections;

public class MenuPlanet : MonoBehaviour {

    public float RotationStep = 0.2f;
    Vector3 eulerAngles;

    public float BounceInterval = 5.0f;
    public float BounceFactor = 1.5f;

    public float BounceStart = 5.0f;
    public float BounceSpeed = 2.5f;

    float bounceTimer;
    float startBounceTimer;

    Vector3 bounceMax;
    Vector3 originalScale;
    Vector3 currentTargetScale;

    float startTime;

    // Use this for initialization
    void Start ()
    {
        eulerAngles = new Vector3(0f, 0f, RotationStep);    // rotation as vector
        bounceTimer = BounceInterval;                       // time between bounces
        originalScale = transform.localScale;               // original size of the planet
        startBounceTimer = BounceStart;                     // when to start bouncing
        // max bounce size
        bounceMax = new Vector3(transform.localScale.x*BounceFactor, transform.localScale.y*BounceFactor, transform.localScale.z);
        currentTargetScale = bounceMax;                     // current target size, bouncing up(bounceMax) or down(originalScale)
    }
    
    // Update is called once per frame
    void Update ()
    {
        bounceTimer -= Time.deltaTime;
        startBounceTimer -= Time.deltaTime;

        if(startBounceTimer < 0f)
        {
            if(bounceTimer < 0f)
            {
                if(startTime == 0f)
                {
                    startTime = Time.time-0.1f;
                }
                float distCovered = (Time.time - startTime) * BounceSpeed;
                float fracJourney = distCovered;// / journeyLength;
                transform.localScale = Vector3.Lerp(transform.localScale, currentTargetScale, fracJourney);
                if(transform.localScale == currentTargetScale)
                {
                    startTime = 0f;
                    currentTargetScale = originalScale;
                }

                // if we have finished bouncing up and down
                if(transform.localScale == originalScale)
                {
                    bounceTimer = BounceInterval;
                    currentTargetScale = bounceMax;
                }
            }
        }

        transform.Rotate(eulerAngles);
    }

}
