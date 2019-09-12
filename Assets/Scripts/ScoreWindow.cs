using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// window for score and increase it 
/// and lifes
/// </summary>
public class ScoreWindow : MonoBehaviour
{
    private Text score;
    static int heartCiunt = 3;
 
    private static Heart[] hearts;

  

    void Awake()
    {
          hearts = new Heart[] {
            new Heart(){ heart =  transform.Find("FirstHeart").GetComponent<Image>(), IsVisible=true} ,
             new Heart(){ heart =  transform.Find("SecondHeart").GetComponent<Image>(), IsVisible=true} ,
              new Heart(){ heart =  transform.Find("ThrirdHeart").GetComponent<Image>(), IsVisible=true} 
        };

      
        score = transform.Find("scoretext").GetComponent<Text>();
    }
    private void Update() {
        score.text = GameHandler.GetScore().ToString();
    }

    public static bool RemoveLife()
    {
        Debug.Log("RemoveLife  hearts.Length " + hearts.Length);
        for (int i = 0; i < hearts.Length; i++)
        {
            Debug.Log(hearts[i].IsVisible);
            if (hearts[i].IsVisible == true)
            {
                Debug.Log("-1 life");
                hearts[i].IsVisible = false;
                hearts[i].heart.enabled = false;
                return true;
            }
        }
        return false;
    }
    public static void AddLife()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (!hearts[i].IsVisible)
            {
                hearts[i].IsVisible = true;
                hearts[i].heart.enabled = true;
                break;
            }
        }
      
    }
    public static bool IsGameOver()
    {
        bool isalive = false;
        Debug.Log("IsGameOver " + hearts.Length);
        for (int i = 0; i < hearts.Length; i++)
        {
            Debug.Log(hearts[i].IsVisible);
            if (hearts[i].IsVisible == true)
            {
                isalive = true;
            }
        }
        return isalive;
    }

    struct Heart {
       public Image heart;
        public bool IsVisible;
    }
}
