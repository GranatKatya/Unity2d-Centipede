using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// class to manage pause window
/// bind actions to buttons
///  and hide some elements
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;// =  new PauseMenu();
 

    private Button resumebutton;
    private Button mainMenu;
  
    void Awake()
    {
       instance = this;    

        transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;

        resumebutton = GameObject.Find("Resume").GetComponent<Button>();
        resumebutton.onClick.AddListener(delegate { GameHandler.ResumeGame(); });
        mainMenu = GameObject.Find("MainMenu").GetComponent<Button>();
        mainMenu.onClick.AddListener(delegate { Loader.LoadMainMenu(Loader.Scene.MainMenu); });

        Hide();
    }
    private void Show() { gameObject.SetActive(true); }
    private void Hide() { gameObject.SetActive(false); }
 
   public static void HideStatic() { instance.Hide(); }




}