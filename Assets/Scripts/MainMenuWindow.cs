using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //void Start()
    //{
    //    _button = GameObject.Find("Play").GetComponent<Button>();
    //    _button.onClick.AddListener(delegate { Loader.Load(); });
    //}
}
 