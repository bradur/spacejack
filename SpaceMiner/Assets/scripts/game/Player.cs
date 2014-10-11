using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public GameObject progressBar;
    public float speed;

    bool onJourney;
    bool asteroidReached;

    Vector2 travelingPoint;
    Progress progressbar;

    void Start ()
    {
        progressbar = progressBar.GetComponent<Progress>();
        onJourney = false;
        asteroidReached = false;
    }

    void Update ()
    {
        if (onJourney) {
            Vector2 dir = (travelingPoint - (Vector2)transform.position).normalized;
            rigidbody2D.velocity = dir * speed;
            if (Mathf.Abs (transform.position.x - travelingPoint.x) < 0.1 && Mathf.Abs (transform.position.y - travelingPoint.y) < 0.1) {
                rigidbody2D.velocity = Vector2.zero;
                onJourney = false;
                // show progress bar only after player has stopped on the asteroid, not immediately when colliding
                if(asteroidReached){
                    progressbar.StartProcess();
                }
            }
        }

    }

    public void MoveTo (Vector3 targetPosition)
    {
        // hide progress bar when player starts to move
        if(asteroidReached){
            progressbar.EndProcess();
        }
        if (!onJourney) {
            onJourney = true;
            travelingPoint = targetPosition;
        }
        asteroidReached = false;
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        
        if (collider.gameObject.tag == "home") {
            
        }
        if (collider.gameObject.tag == "asteroid") {
            asteroidReached = true;
            progressbar.SetTarget(collider.gameObject);
        }
    
    }

}
