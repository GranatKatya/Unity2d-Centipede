using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private Text score;
    static int heartCiunt = 3;
   // private static Image[] hearts;
    private static Heart[] hearts;

    // Update is called once per frame

    void Awake()
    {
        //hearts = new Image[] { transform.Find("FirstHeart").GetComponent<Image>(), transform.Find("SecondHeart").GetComponent<Image>(), transform.Find("ThrirdHeart").GetComponent<Image>() };
        hearts = new Heart[] {
            new Heart(){ heart =  transform.Find("FirstHeart").GetComponent<Image>(), IsVisible=true} ,
             new Heart(){ heart =  transform.Find("SecondHeart").GetComponent<Image>(), IsVisible=true} ,
              new Heart(){ heart =  transform.Find("ThrirdHeart").GetComponent<Image>(), IsVisible=true} 
        };

        //Debug.Log("Image[] hearts; " + hearts.Length);
        //Debug.Log("Image[] hearts; " + hearts[0].heart);
        //Debug.Log("Image[] hearts; " + hearts[1].heart);
        //// hearts[1].heart.enabled = false;    
        //Debug.Log("Image[] hearts; " + hearts[2].heart);
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
