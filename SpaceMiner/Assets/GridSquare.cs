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

    bool dead = false;
    int row;
    int column;
    // Use this for initialization
    void Start () {
        
        //print(sr.sprite.rect.width);
        //print(sr.sprite.bounds.size);
        originalColor = sr.color;
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    void Kill(){
        Disable();
        dead = true;
    }

    public void Disable(){
        gameObject.SetActive(false);
        
    }

    public void Enable(){
        //print("Enable: y: "+ row +" <> x: "+column+" SiblingIndex: "+transform.GetSiblingIndex());
        if(!dead){
            gameObject.SetActive(true);
        }
    }

    public void SetPosition(int row, int column){
        this.row = row;
        this.column = column;
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
        //print("y: "+ row +" <> x: "+column+" SiblingIndex: "+transform.GetSiblingIndex());
        transform.parent.gameObject.GetComponent<GridManager>().SquareDestroyed(row, column);
        Kill();
    }

    void OnMouseDown(){
        sr.color = activeColor;
    }
}
