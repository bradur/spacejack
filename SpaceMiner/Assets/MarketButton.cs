using UnityEngine;
using System.Collections;



public class MarketButton : MonoBehaviour {

    public Resource costType;
    public Resource rewardType;

    public int costValue;
    public int rewardValue;

    public GameObject backGround;
    public Sprite activeSprite;
    public Sprite disabledSprite;
    Sprite originalSprite;

    public AudioSource clickSound;
    public AudioSource failSound;
    SpriteRenderer sr;

    public GameObject MarketManagerObject;
    MarketManager marketManager;

    public bool is_enabled = true;

    void Awake(){
        sr = backGround.GetComponent<SpriteRenderer>();
        originalSprite = sr.sprite;
        marketManager = MarketManagerObject.GetComponent<MarketManager>();
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DisableButton(){
        is_enabled = false;
        sr.sprite = disabledSprite;
    }

    void EnableButton(){
        is_enabled = true;
        sr.sprite = originalSprite;
    }

    public void CheckAvailability(int count){
        if(count < costValue){
            DisableButton();
            //print("Not enough("+costValue.ToString()+") "+costType+"("+count.ToString()+")!");
        }
        else{
            EnableButton();
        }
    }

    void OnMouseUp(){
        sr.sprite = originalSprite;
    }

    void OnMouseDown(){
        if(is_enabled){
            clickSound.Play();
            marketManager.UpdateResourceCount(costType, -costValue);
            marketManager.UpdateResourceCount(rewardType, rewardValue);
        }
        else{
            failSound.Play();
        }
        sr.sprite = activeSprite;
    }
}
