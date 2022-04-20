using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : Collidable    // estende la classe Collidable
{
    public string[] sceneNames;     // array di stringhe contenenti i nomi delle scene

    protected override void OnCollide(Collider2D coll)  // override del metodo OnCollide della classe Collidable
    {
        // GameManager.instance.ShowText(...); per mostrare il testo 
        if(coll.name == "Player")           // se la collisione avviene con il player  
        {
            // teletrasporto il player
            GameManager.instance.SaveState();       // salvo lo stato del gioco
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)]; // scelgo una scena a caso tra quelle presenti
            SceneManager.LoadScene(sceneName);      // carico la scena
        }
    }
}
