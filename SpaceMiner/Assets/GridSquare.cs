using UnityEngine;
using System.Collections;

public class GridSquare : MonoBehaviour {

    public Color hoverColor;
    public Color activeColor;
    public Color oddColor;

    SpriteRenderer sr;
    Color originalColor;
    void Awake(){
        sr = GetComponent<SpriteRenderer>();
    }


    // Use this for initialization
    void Start () {
        
        //print(sr.sprite.rect.width);
        //print(sr.sprite.bounds.size);
        originalColor = sr.color;
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    public void Odd(){
        sr.color = oddColor;
    }

    void OnMouseEnter(){
        sr.color = hoverColor;
    }

    void OnMouseExit(){
        sr.color = originalColor;
    }

    void OnMouseUp(){
        sr.color = originalColor;
    }

    void OnMouseDown(){
        sr.color = activeColor;
    }
}
