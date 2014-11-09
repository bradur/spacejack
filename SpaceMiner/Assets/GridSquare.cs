using UnityEngine;
using System.Collections;

public class GridSquare : MonoBehaviour {

    public Color hoverColor;
    public Color activeColor;

    SpriteRenderer sr;
    Color originalColor;
    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        print(sr.sprite.rect.width);
        print(sr.sprite.bounds.size);
        originalColor = sr.color;
    }
    
    // Update is called once per frame
    void Update () {
    
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
