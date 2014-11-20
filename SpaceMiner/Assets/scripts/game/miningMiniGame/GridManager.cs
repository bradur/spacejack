using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridManager : MonoBehaviour {

    // editor variables
    public int columns = 5;                             // how many columns
    public int rows = 5;                                // how many rows
    public GameObject background;                       // background object
    public float maxSurprisePercentage = 0.2f;          // maximum percentage of surprises per blocks
    public float surpriseFactor = 0.85f;                // chance of surprise spawning

    // local variables
    SpriteRenderer sr;                                  // renderer for the background
    Object squarePrefab;                                // square prefab
    Texture2D texture;                                  // background texture (will be drawn on!)

    int width;                                          // texture width
    int height;                                         // texture height
    int maxSurprises;                                   // maximum amount of surprises (calculated from maxSurprisePercentage)

    List<int> shuffleBag = new List<int>();             // list for shuffle

    Color[] transParent;                                // transparent color (used as an "eraser" on texture)

    void Awake(){
        squarePrefab = Resources.Load("gridSquare");
        int squares = (rows-1)*columns;                 // calculate squares (except last row)
        maxSurprises = (int)(maxSurprisePercentage*squares);
        if(maxSurprises >= squares){
            maxSurprises = squares;
        }
        else if(maxSurprises <= 0){
            maxSurprises = 0;
        }
        //print(maxSurprises);
        maxSurprises = 5;
        for(int i = 0;i < squares; i++){
            shuffleBag.Add(i);
        }
        GenerateGrid();
    }


    // Use this for initialization
    void Start () {
        float moveX = columns/2;
        float moveY = rows/2;

        sr = background.GetComponent<SpriteRenderer>();
        
        //PixelsToUnits = sr.sprite.rect.width / sr.sprite.bounds.size.x;
        background.transform.position = new Vector3(transform.position.x-moveX, transform.position.y-moveY);
        //float viewPortUnits = Camera.main.orthographicSize*2f*(Screen.width/Screen.height);

        transParent = new Color[64*64];
        for(int i = 0;i < transParent.Length; i++){
            transParent[i] = Color.clear;
        }
        width = sr.sprite.texture.width;
        height = sr.sprite.texture.height;
        texture = sr.sprite.texture;
    }
    
    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SquareDestroyed(int row, int column){
        //print("Destroyed: y: "+row+ " <> x: "+column);
        // squares are laid out like this:
        /*
         x    0  1  2  3  4  
           .----------------.
         0 | 00 01 02 03 04 |
         1 | 05 06 07 08 09 |
         2 | 10 11 12 13 14 |
         3 | 15 16 17 18 19 |
         4 | 20 21 22 23 24 |
         y '----------------'
           
           so 24 is 24 because it's 5*5 (zero index)
           you can use transform.GetChild() to get a specific square
        */
        for(int i = 0; i < row+1; i++){
            for(int j = 0; j <= columns; j++){
                print("never");
                transform.GetChild(i*columns+j).gameObject.GetComponent<GridSquare>().Disable();
            }
        }

        for(int i = row; i <= row+1; i++){
            if(i == rows){
                print("cont1: i"+i+" <> row"+row);
                continue;
            }
            for(int j = column-1; j <= column +1; j++){
                if(j == -1 || j == columns){
                    print("cont2: j"+j+" <> column"+column);
                    continue;
                }
                if(i == row+1 && j != column){
                    print("cont3: j"+j+" <> column"+column);
                    continue;
                }
                transform.GetChild(i*columns+j).gameObject.GetComponent<GridSquare>().Enable();
            }
        }

        // draw transparent pixels on texture to simulate destruction
        Color[] pixels = texture.GetPixels();                                                   // get pixel array from old texture
        texture = new Texture2D(width, height, TextureFormat.ARGB32, false);                    // initialize new Texture2D in ARGB(alpha rgb, alpha is for transparency)
        texture.SetPixels(pixels);                                                              // set old texture pixels on new texture
        texture.SetPixels(width-(columns-column)*64, height-64-row*64, 64, 64, transParent);    // set one block worth of transparent pixels on texture on correct spot
        texture.Apply();                                                                        // apply texture. remember to do this!
        sr.sprite = Sprite.Create(texture, sr.sprite.rect, new Vector2(0.5f, 0.5f), 64);        // create new sprite and set it as our sprite
        // end of draw transparent pixels

    }

    // pick randomly from a "bag"
    // bag here: indices of all squares above mineral level
    int Shuffle(){
        int randomShuffle;
        while(shuffleBag.Count > 0){
            randomShuffle = Random.Range(0, shuffleBag.Count);
            if(shuffleBag.Contains(randomShuffle)){
                shuffleBag.Remove(randomShuffle);
                return randomShuffle;
            }
        }
        return -1;
    }

    GameObject GenerateSquare(){
        GameObject newSquare = (GameObject)Instantiate(squarePrefab);
        newSquare.transform.parent = transform;
        //newSquare.SetActive(false);
        return newSquare;
    }

    void GenerateGrid(){
        for(int i = 0; i < rows; i++){
            for(int j = columns-1; j >= 0; j--){
                GameObject square = GenerateSquare();
                GridSquare gridSquare = square.GetComponent<GridSquare>();
                gridSquare.SetPosition(i, columns-1-j);
                if(i == 0){
                    gridSquare.Enable();        // enable first row
                }
                square.transform.localPosition = new Vector3(-1f*j, -1f*i, 0f);
            }
        }

        int shuffle;
        for(int i = 0; i < maxSurprises; i++){
            if(Random.value > surpriseFactor){
                shuffle = Shuffle();
                if(shuffle == -1){
                    break;
                }
                transform.GetChild(shuffle).GetComponent<GridSquare>().AddSurprise();
                //print("Surprise added to: "+shuffle);
            }

        }


    }
}
