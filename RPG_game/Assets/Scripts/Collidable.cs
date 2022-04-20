using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(BoxCollider2D))]  // aggiunge automaticamente un collider all'oggetto (non sempre va bene ) 



public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;      // per filtrare su cosa il player deve collidere
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10]; // contiene i dati delle collisioni in un frame (10 è già un buon numero)
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // i metodi protected virtual possono essere overridden  
    protected virtual void Update()     
    {
        // controlla se ci sono collisioni che vengono poi inserite nell'array hits  
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++) 
        {
            if (hits[i] == null)
                continue;           // migliorabile 
            // Debug.Log(hits[i].name);
            OnCollide(hits[i]);     // se c'è una collisione chiamo la funzione OnCollide per gestirla
            hits[i] = null; 
        }   
    }

    protected virtual void OnCollide(Collider2D coll) // funzione che gestisce le collisioni 
    {
       Debug.Log(coll.name); 
    }              
    


}
