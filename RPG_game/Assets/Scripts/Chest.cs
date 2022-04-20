using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount = 5;     // quello che contiene la chest? 

    protected override void OnCollect()     
    {

       if (!collected)
       {
           collected = true;
           GetComponent<SpriteRenderer>().sprite = emptyChest;      // cambia la sprite della chest 
           Debug.Log("Ottenute" + pesosAmount + "monete");
           GameManager.instance.ShowText("+" + pesosAmount + " pesos!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
       } 

    }
}
