using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour
{
    public Color hoverColor;
    public Color activeColor;

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
        sr.color = originalColor;
        Application.LoadLevel (1);
    }

    void OnMouseDown()
    {
        sr.color = activeColor;
    }

}
