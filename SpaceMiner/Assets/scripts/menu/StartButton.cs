using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour
{
    public Color hoverColor;
    public Color activeColor;
    public AudioSource clickSound;

    public int LevelToLoad = 1;

    Color originalColor;
    SpriteRenderer sr;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    void OnMouseExit()
    {
        sr.color = originalColor;
    }

    void OnMouseUp()
    {
        clickSound.Play();
        sr.color = originalColor;
        Application.LoadLevel(LevelToLoad);
    }

    void OnMouseDown()
    {
        sr.color = activeColor;
    }

}
