using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// try to manage game in this class
/// </summary>
public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;
    private static int score;
    public GameObject youwin;  

   void Awake()
    {
        instance = this;
        InitializedStatic();
    }
  

    private static void InitializedStatic() { score = 0; }
    public static int GetScore() { return score; }// returs score
    public static void AddScore(int addscore = 100) { score += addscore; }


    public static void ResumeGame() // Resume Gam
    {
        PauseMenu.HideStatic();
        Time.timeScale = 1f;
    }
    public static void StopeGame()// Stope Game
    {
        Time.timeScale = 0f;
    }
  
}
