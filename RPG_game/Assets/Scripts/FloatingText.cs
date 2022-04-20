using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ogni volta che si vuole creare un testo: click destro -> nuovo canvas -> rinomino in FloatingTest a cui aggiungo FloatingTextMangar script 

public class FloatingText
{
    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show() 
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    public void Hide() 
    {
        active = false;
        go.SetActive(active); 
    }

    public void UpdateFloatingText()
    {
        if (!active)
            return;

        if (Time.time - lastShown > duration)
            Hide();  

        go.transform.position += motion * Time.deltaTime;
    }

}
