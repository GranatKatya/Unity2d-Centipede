using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;
    private static int score;
    public GameObject youwin;
   // public static GameObject button;
    //public GameObject Mybutton;

    //public void ShowButton()
    //{
    //    Mybutton.SetActive(true);
    //}
    //public void HideButton()
    //{
    //    Mybutton.SetActive(false);
    //}

    private void Start() {
       // CMDebug.ButtonUi
    }
   void Awake()
    {
        instance = this;
        InitializedStatic();
      //  HideButton();
    }
  

    private static void InitializedStatic() { score = 0; }
   public static int GetScore() { return score; }
    public static void AddScore(int addscore = 100) { score += addscore; }



    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.Escape))
    //    {
    //        GameHandler.PauseGame();
    //    }
    //}
    public static void ResumeGame()
    {
        PauseMenu.HideStatic();
        Time.timeScale = 1f;
    }
    public static void StopeGame()
    {
        Time.timeScale = 0f;
    }
    //public static void PauseGame()
    //{
    //    PauseMenu.ShowStatic();
    //    Time.timeScale = 0f;
    //}
}
