using UnityEngine;
using System.Collections;

public class ScreenResize : MonoBehaviour {

    // Use this for initialization
    void Start () {
        ResizeSpriteToScreen();
    }

    public void ResizeSpriteToScreen() {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null){return;}
        transform.localScale = new Vector3(1,1,1);
        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;
        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1.0f);
        //transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update () {
    
    }
}