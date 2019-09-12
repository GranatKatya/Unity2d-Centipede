using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;// =  new PauseMenu();
  //  public  GameObject GameObject;

    private Button resumebutton;
    private Button mainMenu;
   // void Start() { instance = this; }
    void Awake()
    {
       instance = this;
       // GameObject = gameObject;

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
   //public static void ShowStatic() { instance.Show(); }
   public static void HideStatic() { instance.Hide(); }



    // void Update()
    //{
    //    if (Input.GetKey(KeyCode.Escape))
    //    {
    //        Debug.Log("______________________________________________--------------------------------------------------------pase");
    //       // Show();
    //        Time.timeScale = 0f;
    //    }
    //}


    //public   void ResumeGame()
    //{
    //    // PauseMenu.HideStatic();
    //   Hide();

    //    Time.timeScale = 1f;
    //}
    //public  void PauseGame()//
    //{
    //    // PauseMenu.ShowStatic();
    //    Show();
    //    Time.timeScale = 0f;
    //}



}