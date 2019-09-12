using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static  class Loader
{
    public enum Scene { four, MainMenu }
    public static  void Load()//reload scene
    {
      //  button = mybutton;
        SceneManager.LoadScene(Scene.four.ToString());
      
    }
    public static void LoadMainMenu(Scene c )//reload scene
    {
        //  button = mybutton;
        SceneManager.LoadScene(c.ToString());
       // HideButton();
    }


}
