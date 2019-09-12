using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonHandler : MonoBehaviour
{
  //  public   GameObject button;
  
    public  void Load()
    {
        Loader.Load();
        HideButton();
    }


    public static void ShowButton()  //show retray button~
    {
        GameObject b = GameObject.Find("retraybutton");
        b.SetActive(true);
    }
    public static void HideButton()//hide retray button
    {
        GameObject b = GameObject.Find("retraybutton");
        b.SetActive(false);
    }

  
}
    