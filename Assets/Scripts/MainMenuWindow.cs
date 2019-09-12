using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// class for main menu window 
/// here it's find buttons and bind  actions to it
/// </summary>
public class MainMenuWindow : MonoBehaviour
{
    private Button _button;
    private Button quitbutton;
    void Awake()
    {
        _button = GameObject.Find("Play").GetComponent<Button>();
        _button.onClick.AddListener(delegate { Loader.Load(); });
        quitbutton  = GameObject.Find("Quit").GetComponent<Button>();
        quitbutton.onClick.AddListener(delegate { Application.Quit(); });
    }

}
 