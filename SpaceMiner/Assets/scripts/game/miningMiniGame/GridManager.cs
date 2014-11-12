using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

    // editor variables

    public int columns = 5;
    public int rows = 5;

    public GameObject background;

    public Color tpColor;
    SpriteRenderer sr;
    Object squarePrefab;
    Texture2D texture;
    //float PixelsToUnits;

    Color[] transParent;

    void Awake(){
        squarePrefab = Resources.Load("gridSquare");
        GenerateGrid();
    }

    int width;
    int height;

    bool firstDestruction = true;

    // Use this for initialization
    void Start () {
        float moveX = columns/2;
        float moveY = rows/2;

        sr = background.GetComponent<SpriteRenderer>();
        
        //PixelsToUnits = sr.sprite.rect.width / sr.sprite.bounds.size.x;
        background.transform.position = new Vector3(transform.position.x-moveX, transform.position.y-moveY);
        //float viewPortUnits = Camera.main.orthographicSize*2f*(Screen.width/Screen.height);

        transParent = new Color[64*64];
        //Color tpColor = new Color(0f, 0f, 0f, 0f);
        for(int i = 0;i < transParent.Length; i++){
            transParent[i] = Color.clear;
        }
        width = sr.sprite.texture.width;
        height = sr.sprite.texture.height;
        texture = sr.sprite.texture;
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    public void SquareDestroyed(int row, int column){
        //transform.GetChild(row+column);
        //print("Destroyed: y: "+row+ " <> x: "+column);
        //GameObject[] children = new GameObject[4];

        /*if(firstDestruction){
            for(int j = 0; j < columns; j++){
                transform.GetChild(j).gameObject.GetComponent<GridSquare>().Disable();
            }
            foreach(Transform child in transform){
                child.gameObject.GetComponent<GridSquare>().Disable();
            }
            firstDestruction = false;
        }*/

        for(int i = 0; i < row; i++){
            for(int j = 0; j <= columns; j++){
                transform.GetChild(i*columns+j).gameObject.GetComponent<GridSquare>().Disable();
            }
        }

        for(int i = row; i <= row+1; i++){
            if(i == rows){
                //print("contROW:"+i);
                continue;
            }
            for(int j = column-1; j <= column +1; j++){
                if(j == -1 || j == columns){
                    //print("contCOL:"+j+i);
                    continue;
                }
                if(i == row+1 && j != column){
                    continue;
                }
                transform.GetChild(i*columns+j).gameObject.GetComponent<GridSquare>().Enable();
            }
        }


        // BLOCK DESTRUCTION SHOWN IN BACKGROUND
        /*var cols = texture.GetPixels();
        for(int i = 0; i*64 < rows; i++) {
            
            for( int j = 0; j < cols.Length; ++j) {
                cols[i] = Color.Lerp( cols[i], colors[mip], 0.33 );
            }
            texture.SetPixels( cols, mip );
        }*/
        // void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors, int miplevel = 0);
        //texture = (Texture2D)GameObject.Instantiate(sr.sprite.texture);

        
        Color[] pixels = texture.GetPixels();
        texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
        texture.SetPixels(pixels);
        //texture.Apply(false);
        //sr.sprite = Sprite.Create(texture, sr.sprite.rect, new Vector2(0.5f, 0.5f), 64);


        texture.SetPixels(width-64-column*64, height-64-row*64, 64, 64, transParent);
        texture.Apply(false);
        sr.sprite = Sprite.Create(texture, sr.sprite.rect, new Vector2(0.5f, 0.5f), 64);
        // BLOCK DESTRUCTION SHOWN IN BACKGROUND

    }

    GameObject GenerateSquare(){
        GameObject newSquare = (GameObject)Instantiate(squarePrefab);
        newSquare.transform.parent = transform;
        newSquare.SetActive(false);
        return newSquare;
    }

    void GenerateGrid(){
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < columns; j++){
                GameObject square = GenerateSquare();
                GridSquare gridSquare = square.GetComponent<GridSquare>();
                /*int oddeven = (columns*i+j)%2;
                if(oddeven > 0){
                    square.GetComponent<GridSquare>().Odd();
                }*/
                gridSquare.SetPosition(i, j);
                if(i == 0){
                    gridSquare.Enable();
                }
                //gridSquare.Enable();
                square.transform.localPosition = new Vector3(-1f*j, -1f*i, 0f);
            }
        }
    }
}
