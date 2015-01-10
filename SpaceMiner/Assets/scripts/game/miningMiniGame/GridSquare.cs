using UnityEngine;
using System.Collections;

public class GridSquare : MonoBehaviour {

    public Color hoverColor;
    public Color activeColor;
    public Color oddColor;


    public SpriteRenderer surpriseSprite;
    public SpriteRenderer resourceSprite;
    public TextMesh popUpText;

    bool hasSurprise;

    Resource resource;
    int resourceCount = 10;

    Animator animator;

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
        if(resource != Resource.None){
            print("Resource yield: "+resource);
        }
        if(surpriseSprite != null){
            surpriseSprite.enabled = false;
        }
        resourceSprite.enabled = true;
        dead = true;

    }

    public bool IsDead(){
        return dead;
    }

    public void AddSurprise(){
        hasSurprise = true;
        if(sr.enabled){
            surpriseSprite.enabled = true;
        }
        animator = GetComponent<Animator>();
    }

    public void Disable(){
        //gameObject.SetActive(false);
        sr.enabled = false;
        //print("Disable: y: "+ row +" <> x: "+column+" SiblingIndex: "+transform.GetSiblingIndex());
        
        //surpriseSprite.enabled = false;
        //resourceSprite.enabled = false;
        gameObject.collider2D.enabled = false;
    }

    public void Enable(){
        //print("Enable: y: "+ row +" <> x: "+column+" SiblingIndex: "+transform.GetSiblingIndex());
        if(!dead){
            //gameObject.SetActive(true);
            sr.enabled = true;
            gameObject.collider2D.enabled = true;
            if(hasSurprise){
                surpriseSprite.enabled = true;
            }
        }
    }

    public void SetResource(Sprite sprite, Resource resourceType, bool enable=true){
        resourceSprite.sprite = sprite;
        resource = resourceType;
        if(enable){
            resourceSprite.enabled = true;
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
        Kill();
        if(hasSurprise){
            string resourceString = resource.ToString();
            popUpText.text = "+ " + resourceCount + " " + char.ToUpper(resourceString[0]) + resourceString.Substring(1).ToLower();
            animator.enabled = true;
        }
        transform.parent.gameObject.GetComponent<GridManager>().SquareDestroyed(row, column, resource, resourceCount);
    }

    void OnMouseDown(){
        sr.color = activeColor;
    }
}
