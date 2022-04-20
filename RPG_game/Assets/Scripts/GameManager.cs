using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour        // creare un gameobj a cui assegnare questo script 
{
    public static GameManager instance;         // una variabile static è accessibile da qualsiasi script scrivendo GameManager.instance

    
    private void Awake()    // chiamata una volta all'avvio del gioco  
    {
        if (GameManager.instance != null) 
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
        
    }

    // Risorse del gioco 
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References 
    public Player player; 
    public FloatingTextManager floatingTextManager;
    
    public int pesos;
    public int experience;


    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
    // save state 
    /*
    * int preferredSkin
    * int pesos
    * int experience
    * int weaponLevel
    */


    public void SaveState() 
    {
        string str = "";
        str += "0" + "|";     // preferredSkin
        str += pesos.ToString() + "|"; 
        str += experience.ToString() + "|"; 
        str += "0";     // weaponLevel
        
        PlayerPrefs.SetString("SaveState", str);
        Debug.Log("Save State");
    }

    public void LoadState(Scene s, LoadSceneMode mode) 
    {
        SceneManager.sceneLoaded -= LoadState;
        
        if (!PlayerPrefs.HasKey("SaveState")) 
            return;

        
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        
        //change skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        // change weapon level
        Debug.Log("Load State");
    }


}
