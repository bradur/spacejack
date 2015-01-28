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
    public Resource resourceType;                       // type of resource the game yields
    public Sprite[] sprites = new Sprite[6];

    public HudManager resourceManager;
    public AudioSource gainResource;
    public AudioSource clickSquare;
    public AudioSource errorSound;
    public Transform squareContainer;
    Animator animator;

    // local variables
    SpriteRenderer sr;                                  // renderer for the background
    Object squarePrefab;                                // square prefab
    Texture2D texture;                                  // background texture (will be drawn on!)

    int width;                                          // texture width
    int height;                                         // texture height
    int squareWidth;                                    // square texture width
    int squareHeight;                                   // square texture height
    int maxSurprises;                                   // maximum amount of surprises (calculated from maxSurprisePercentage)
    int gameWidth;
    int gameHeight;
    int marginY;
    int marginX;

    float scale_x;
    float scale_y;

    float gameScaleX;
    float gameScaleY;
    Texture2D cachedTexture;
    Asteroid currentAsteroid;
    //Transform transform;

    List<int> shuffleBag = new List<int>();             // list for shuffle

    Color[] transParent;                                // transparent color (used as an "eraser" on texture)
    int movesMade = 0;

    int squaresLeftOnLastRow;

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
        squaresLeftOnLastRow = columns;
        //print(maxSurprises);
        //print(squares);
        //print(maxSurprises);
        //maxSurprises = 5;
        for(int i = 0;i < squares; i++){
            shuffleBag.Add(i);
        }
        //print(shuffleBag.Count);

        GameObject newSquare = (GameObject)Instantiate(squarePrefab);
        squareWidth = newSquare.GetComponent<SpriteRenderer>().sprite.texture.width;
        squareHeight = newSquare.GetComponent<SpriteRenderer>().sprite.texture.height;
        gameWidth = squareWidth*columns;
        gameHeight = squareHeight*rows;
        scale_x = newSquare.transform.localScale.x;
        scale_y = newSquare.transform.localScale.y;
        sr = background.GetComponent<SpriteRenderer>();
        width = sr.sprite.texture.width;
        height = sr.sprite.texture.height;
        cachedTexture = new Texture2D(width, height);
        cachedTexture.SetPixels(sr.sprite.texture.GetPixels());
        cachedTexture.Apply();

        animator = GetComponent<Animator>();
    }


    // Use this for initialization
    void Start () {
        /*
        //transform = transform;
        float moveX = columns/2;
        float moveY = rows/2;

        gameScaleX = transform.localScale.x;
        gameScaleY = transform.localScale.y;
        //background.transform.localScale = new Vector3(gameScaleX, gameScaleY, 1f);
        sr = background.GetComponent<SpriteRenderer>();
        
        //PixelsToUnits = sr.sprite.rect.width / sr.sprite.bounds.size.x;
        
        //float viewPortUnits = Camera.main.orthographicSize*2f*(Screen.width/Screen.height);
        width = sr.sprite.texture.width;
        height = sr.sprite.texture.height;

        marginX = (int)(width-gameWidth);
        marginY = (int)(height-gameHeight);
        background.transform.localPosition = new Vector3(-moveX, -moveY, 1f);
         * */
        /*background.transform.localPosition = new Vector3(
            transform.localPosition.x-moveX-(marginX/2/squareWidth*gameScaleX),
            transform.localPosition.y-moveY-(marginY/2/squareHeight*gameScaleY)
        );*/
        /*
        transParent = new Color[squareWidth*squareHeight];
        for(int i = 0;i < transParent.Length; i++){
            transParent[i] = Color.clear;
        }*/

    }


    void InitializeTexture()
    {
        float moveX = columns / 2;
        float moveY = rows / 2;

        gameScaleX = transform.localScale.x;
        gameScaleY = transform.localScale.y;
        //background.transform.localScale = new Vector3(gameScaleX, gameScaleY, 1f);

        //PixelsToUnits = sr.sprite.rect.width / sr.sprite.bounds.size.x;

        //float viewPortUnits = Camera.main.orthographicSize*2f*(Screen.width/Screen.height);
 

        marginX = (int)(width - gameWidth);
        marginY = (int)(height - gameHeight);
        background.transform.localPosition = new Vector3(-moveX, -moveY, 1f);
        /*background.transform.localPosition = new Vector3(
            transform.localPosition.x-moveX-(marginX/2/squareWidth*gameScaleX),
            transform.localPosition.y-moveY-(marginY/2/squareHeight*gameScaleY)
        );*/
        transParent = new Color[squareWidth * squareHeight];
        for (int i = 0; i < transParent.Length; i++)
        {
            transParent[i] = Color.clear;
        }
        
        sr.sprite = Sprite.Create(                      // create new sprite and set it as our sprite
            cachedTexture,                              // Texture2D texture
            sr.sprite.rect,                             // Rect rect
            new Vector2(0.5f, 0.5f),                    // Vector2 pivot
            squareWidth                                 // float pixelsToUnits
        );
        texture = sr.sprite.texture;
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnMouseUp()
    {
        EndMiniGame();
    }

    public void InitializeGame(Asteroid asteroid)
    {
        transform.parent.gameObject.SetActive(true);
        resourceType = asteroid.mineralType;
        currentAsteroid = asteroid;
        squaresLeftOnLastRow = columns;
        InitializeTexture();
        GenerateGrid();

    }

    void EndMiniGame()
    {
        resourceType = Resource.None;
        GetComponent<BoxCollider2D>().enabled = false;
        currentAsteroid.RestartPirateShip();
        foreach (Transform child in squareContainer)
        {
            Destroy(child.gameObject);
        }
        animator.CrossFade("tap_idle", 0f);
        animator.SetBool("finished", false);
        transform.parent.gameObject.SetActive(false);
    }

    public void SquareDestroyed(int row, int column, Resource resource, int resourceCount)
    {
        clickSquare.Play();
        // Add resource to player if there is any
        if (resource != Resource.None)
        {
            resourceManager.UpdateResourceCount(resource, resourceCount);
            gainResource.Play();
        }

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
           
           you can use transform.GetChild() to get a specific square
        */

        // 1. Disable all squares that are on the same row or above
        for(int i = 0; i <= row; i++){
            for(int j = 0; j <= columns-1; j++){
                //print(i+" : "+(i*columns+j));
                squareContainer.GetChild(i * columns + j).gameObject.GetComponent<GridSquare>().Disable();
            }
        }

        // 2. Enable the square to the left of current position (or if there is empty space in between the next non-empty square)
        for(int j = column; j <= columns-1; j++){
            GridSquare gs = squareContainer.GetChild(row * columns + j).gameObject.GetComponent<GridSquare>();
            if(!gs.IsDead()){
                gs.Enable();
                break;
            }
        }

        // 3. Enable the square to the right of current position (or if there is empty space in between the next non-empty square)
        for(int j = column; j >= 0; j--){
            GridSquare gs = squareContainer.GetChild(row * columns + j).gameObject.GetComponent<GridSquare>();
            if(!gs.IsDead()){
                gs.Enable();
                break;
            }
        }

        // 4. If not the final row, enable the square directly underneath
        if(row != rows-1){
            squareContainer.GetChild((row + 1) * columns + column).gameObject.GetComponent<GridSquare>().Enable();
        }

        // draw transparent pixels on texture to simulate destruction
        Color[] pixels = texture.GetPixels();                                                   // get pixel array from old texture
        texture = new Texture2D(width, height, TextureFormat.ARGB32, false);                    // initialize new Texture2D in ARGB(alpha rgb, alpha is for transparency)
        texture.SetPixels(pixels);                                                              // set old texture pixels on new texture
        
        /*print(width-squareWidth-(columns-column)*squareWidth + "// int x");
        print(height-marginY-squareHeight-row*squareHeight + "// int y");
        print(marginY + "// marginY");
        print(marginX + "// marginX");*/
        
        texture.SetPixels(                                                                      // set one block worth of transparent pixels on texture on correct spot
            width-marginX/2-(columns-column)*squareWidth,         // int x
            height-marginY/2-(row+1)*squareHeight,            // int y
            squareWidth,                                // int blockWidth
            squareHeight,                               // int blockHeight
            transParent                                 // Color[] colors
            // int miplevel = 0
        );
        /*texture.SetPixels(                                                                      // set one block worth of transparent pixels on texture on correct spot
            width-squareWidth-(columns-column)*squareWidth,         // int x
            height-marginY-row*squareHeight,            // int y
            squareWidth,                                // int blockWidth
            squareHeight,                               // int blockHeight
            transParent                                 // Color[] colors
            // int miplevel = 0
        );*/
        texture.Apply();                                                                        // apply texture. remember to do this!
        sr.sprite = Sprite.Create(                                                              // create new sprite and set it as our sprite
            texture,                                    // Texture2D texture
            sr.sprite.rect,                             // Rect rect
            new Vector2(0.5f, 0.5f),                    // Vector2 pivot
            squareWidth                                 // float pixelsToUnits
        );
        // end of draw transparent pixels
        movesMade += 1;
    }

    // pick randomly from a "bag"
    // bag here: indices of all squares above mineral level
    int Shuffle(){
        int randomShuffle;
        while(shuffleBag.Count > 0){
            //randomShuffle = Random.Next(shuffleBag.Count);
            randomShuffle = Random.Range(0, shuffleBag.Count);
            if(shuffleBag.Contains(randomShuffle)){
                shuffleBag.Remove(randomShuffle);
                return randomShuffle;
            }
        }
        return -1;
    }

    Resource GetRandomResource(){
        // random resource (no minerals)
        // 4 == credits
        // 5 == lifesupport
        // 6 == fuel
        return (Resource)Random.Range(4, 7);
    }

    GameObject GenerateSquare(){
        GameObject newSquare = (GameObject)Instantiate(squarePrefab);
        newSquare.transform.parent = squareContainer;
        newSquare.transform.localScale = Vector3.one;
        //newSquare.SetActive(false);
        return newSquare;
    }

    // exploding animation after selecting last row
    public void DestroyLastRow(int currentColumn, int direction=0){
        int nextColumn = currentColumn + direction;
        //print(squaresLeftOnLastRow);
        //print(nextColumn);
        if (nextColumn < columns && nextColumn > -1 && squaresLeftOnLastRow > 0)
        {
            if (direction == 0)
            {
                GridSquare gs = squareContainer.GetChild((rows - 1) * columns + nextColumn + 1).gameObject.GetComponent<GridSquare>();
                gs.ExplodeAndDie(1);

                GridSquare gs2 = squareContainer.GetChild((rows - 1) * columns + nextColumn - 1).gameObject.GetComponent<GridSquare>();
                gs2.ExplodeAndDie(-1);
                squaresLeftOnLastRow--;
                squaresLeftOnLastRow--;
                squaresLeftOnLastRow--;
            }
            else
            {
                GridSquare gs = squareContainer.GetChild((rows - 1) * columns + nextColumn).gameObject.GetComponent<GridSquare>();
                gs.ExplodeAndDie(direction);
                squaresLeftOnLastRow--;
            }
            
        }
        if (squaresLeftOnLastRow < 1 && squaresLeftOnLastRow != -10)
        {
            squaresLeftOnLastRow = -10;
            animator.SetBool("finished", true);
            foreach (Transform child in squareContainer)
            {
                child.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    void GenerateGrid(){
        for(int i = 0; i < rows; i++){
            for(int j = columns-1; j >= 0; j--){
                GameObject square = GenerateSquare();
                GridSquare gridSquare = square.GetComponent<GridSquare>();
                gridSquare.errorSound = errorSound;
                gridSquare.SetPosition(i, columns-1-j);
                if (i == rows-1)
                {
                    gridSquare.isLastRow = true;
                }
                if(i == 0){
                    gridSquare.Enable();        // enable first row
                }
                if(i == rows-1){
                    gridSquare.SetResource(sprites[(int)resourceType], resourceType);
                }
                square.transform.localPosition = new Vector3(-scale_x*j, -scale_y*i, 0f);
            }
        }
        
        int shuffle;
        for(int i = 0; i < maxSurprises; i++){
            if(surpriseFactor > Random.value){
                shuffle = Shuffle();
                //print(shuffleBag.Count);
                if(shuffle == -1){
                    break;
                }
                GridSquare gridSquare = squareContainer.GetChild(shuffle).GetComponent<GridSquare>();
                if (gridSquare != null)
                {
                    gridSquare.AddSurprise();
                    Resource surpriseResource = GetRandomResource();
                    gridSquare.SetResource(sprites[(int)surpriseResource], surpriseResource, false);
                }
                //print("Surprise added to: "+shuffle);
            }
        }


    }
}
