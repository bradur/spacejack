using UnityEngine;
using System.Collections;



public class MarketButton : MonoBehaviour {

    public Resource costType;
    public Resource rewardType;

    public int costValue;
    public int rewardValue;

    public SpriteRenderer sr;
    public Sprite activeSprite;
    public Sprite disabledSprite;
    Sprite currentSprite;
    Sprite originalSprite;

    public AudioSource clickSound;
    public AudioSource failSound;

    public MarketManager marketManager;

    public bool is_enabled = true;

    void Awake(){
        originalSprite = sr.sprite;
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
        currentSprite = disabledSprite;
    }

    void EnableButton(){
        is_enabled = true;
        sr.sprite = originalSprite;
        currentSprite = originalSprite;
    }

    public void CheckAvailability(int count){
        //print("["+costType.ToString() + "] cost: "+costValue.ToString()+" - count: " + count.ToString());
        if(count < costValue){
            DisableButton();
            print("[disable] "+rewardType.ToString() + " for "+costType.ToString());
            //print("Not enough("+costValue.ToString()+") "+costType+"("+count.ToString()+")!");
        }
        else{
            EnableButton();
        }
    }

    void OnMouseUp(){
        
        sr.sprite = currentSprite;
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
