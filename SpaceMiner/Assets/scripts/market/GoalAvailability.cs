using UnityEngine;
using System.Collections;

public class GoalAvailability : MonoBehaviour {

    public TextMesh goalText;

    public Color fadeColor;
    Color originalColor;

    public GameObject goalChecked;
    public int goalValue;
    public Resource goalType;

    string originalText;

	// Use this for initialization
	void Start () {
        originalColor = goalText.color;
        originalText = goalText.text;
	}

    public void UpdateGoal(int currentValue){
        if(currentValue >= goalValue)
        {
            goalText.color = originalColor;
            goalChecked.SetActive(true);
            goalText.text = originalText;
        }
        else
        {
            goalText.color = fadeColor;
            goalChecked.SetActive(false);
            goalText.text = originalText + "("+goalValue+" "+goalType+")";
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
