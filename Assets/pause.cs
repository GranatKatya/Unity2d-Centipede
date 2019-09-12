using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausemenuui;

    public float period = 0.0f;


    private Button resumebutton;
    private Button mainMenu;
    // void Start() { instance = this; }
    void Awake()
    {
        InitializedStatic(); 
        //transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        //transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;

        resumebutton = GameObject.Find("Resume").GetComponent<Button>();
        resumebutton.onClick.AddListener(delegate { Resume(); });
        mainMenu = GameObject.Find("MainMenu").GetComponent<Button>();
        mainMenu.onClick.AddListener(delegate { Loader.LoadMainMenu(Loader.Scene.MainMenu); });

        //pausemenuui.SetActive(false);
        //GameIsPaused = false;
        Resume();
    }
    private static void InitializedStatic() { GameIsPaused = false; }

    void Update()
    {
        if (period > 0.1)
        {
            if (Input.GetKey(KeyCode.Escape))
            {

                Debug.Log("Escape");
                Debug.Log(GameIsPaused);
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }

            }
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;

    }
    public void Resume() {
        pausemenuui.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        Debug.Log("Resume");
        Debug.Log(GameIsPaused);
    }
    public void Pause()
    {
        pausemenuui.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Debug.Log("Pause");
        Debug.Log(GameIsPaused);
    }
}
