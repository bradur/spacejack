using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

    // editor variables

    public int columns = 5;
    public int rows = 5;

    public GameObject background;


    SpriteRenderer sr;
    Object squarePrefab;
    //float PixelsToUnits;

    void Awake(){
        squarePrefab = Resources.Load("gridSquare");
        GenerateGrid();
    }

    // Use this for initialization
    void Start () {
        float moveX = columns/2;
        float moveY = rows/2;
        sr = background.GetComponent<SpriteRenderer>();
        //PixelsToUnits = sr.sprite.rect.width / sr.sprite.bounds.size.x;
        background.transform.localPosition = new Vector3(moveX, moveY);
        //float viewPortUnits = Camera.main.orthographicSize*2f*(Screen.width/Screen.height);
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    GameObject GenerateSquare(){
        GameObject newSquare = (GameObject)Instantiate(squarePrefab);
        newSquare.transform.parent = transform;
        return newSquare;
    }

    void GenerateGrid(){
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < columns; j++){
                GameObject square = GenerateSquare();
                int oddeven = (columns*i+j)%2;
                if(oddeven > 0){
                    square.GetComponent<GridSquare>().Odd();
                }
                square.transform.localPosition = new Vector3(1f*j, 1f*i, 0f);
            }
        }
    }
}
