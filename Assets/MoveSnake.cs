
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSnake : MonoBehaviour
{



    public GameObject button;//retray button
    public GameObject pauseWindow;
    public GameObject youwin;
    public GameObject youlose;

   

    public GameObject mashroomPrefab;
    

    private Vector2Int gridMoveDirection;// right direction
    private Vector2Int gridPosition;
    public string direction = "right";
  
      public int goDown = 0;
   
    public bool  ifDown = false;




    [SerializeField]
    private int xStartPosition;
    [SerializeField]
    private int yStartPsition;
   

    public float period = 0.0f;
  
    GameObject[] mushroomsObjects;//array for objects with tag  "mushrooms"
    GameObject[] сentipedeObjects;// array for objects with tag  "snakehead"
  
    void Start()
    {       
        сentipedeObjects = GameObject.FindGameObjectsWithTag("snakehead");//find all objects with tag 
      
        mushroomsObjects = GameObject.FindGameObjectsWithTag("mushroom");     
    }



    private void Awake()
    {
        gridPosition = new Vector2Int(xStartPosition, yStartPsition);
        gridMoveDirection = new Vector2Int(1, 0);// move to right 
        button.SetActive(false);

        youwin.SetActive(false);// hide window
        youlose.SetActive(false);
    }



    private void Update()
    {

        if (period > 0.5)
        {

            if (ifDown)
            {
              int res =  CanIGoThere("down");
                if (res == -1)
                {
                    ifDown = false;
                    return;
                }
               

                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
                //  gridPosition.y -= 1;
                gridPosition += gridMoveDirection;
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
                transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) + 90);

                goDown += 1;
                if (goDown == 1)
                {
                    ifDown = false;
                    if (direction == "right")
                    {
                        direction = "left";
                    }
                    else if (direction == "left")
                    {
                        direction = "right";
                    }
                    goDown = 0;
                }


            }
            else
            {
                if (direction == "right")
                {
                    int res = CanIGoThere("right");
                    if (res == -1)
                    {                     
                        return;
                    }


                    gridMoveDirection.x = +1;
                    gridMoveDirection.y = 0;
                    //   gridPosition.x += 1;//right
                    gridPosition += gridMoveDirection;
                    transform.position = new Vector3(gridPosition.x, gridPosition.y);
                    transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) - 90);

                    //   alowChange = true;
                }
                if (direction == "left")
                {
                     int res = CanIGoThere("left");
                    if (res == -1)
                    {
                        return;
                    }
            
                    Debug.Log(" go left ");

                        gridMoveDirection.x = -1;
                        gridMoveDirection.y = 0;
                        // gridPosition.x -= 1;
                        gridPosition += gridMoveDirection;
                        transform.position = new Vector3(gridPosition.x, gridPosition.y);
                        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) - 90);

                        //  alowChange = true;
                   // }


                }
            }



            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
    }


    private bool IsCentipadeDie() // neeed to ckeck if there are parts of centipade or on
    {
        Debug.Log("IsCentipadeDie");
       
        сentipedeObjects = GameObject.FindGameObjectsWithTag("snakehead");
        
        if (сentipedeObjects.Length -1 > 0)
        {            
                 return false;
        }
        else
        {
               return true;//die
        }
    }
    private int IsCentipedeBodyExistsThereAndКedirect(string mydirection)
    {
        сentipedeObjects = GameObject.FindGameObjectsWithTag("snakehead");
        bool isexists = false;
        Vector3 checkposition = new Vector3(transform.position.x, transform.position.y);//create the vector to save position and change some parameters

        Vector3 checkposition1 = new Vector3(transform.position.x, transform.position.y);//for 2 nearest way
        Vector3 checkposition2 = new Vector3(transform.position.x, transform.position.y);
        bool isfreedirection1 = true;// check if the path is clear
        bool isfreedirection2 = true;// check if the path is clear

        if (mydirection == "left")// cange corresponding coordinates
        {
            checkposition.x = checkposition.x - 1;
            checkposition1.x += 1;//right
            checkposition2.y -= 1;//down
        }
        if (mydirection == "right")// cange corresponding coordinates
        {
            checkposition.x = checkposition.x + 1;
            checkposition1.x -= 1;//left
            checkposition2.y -= 1;//down
        }
        if (mydirection == "down")// cange corresponding coordinates
        {
            checkposition.y = checkposition.y - 1;
            checkposition1.x += 1;//right
            checkposition2.x -= 1;//left
        }

        Debug.Log("checkposition " + checkposition + " ?=?  transform.position " + transform.position);
        Debug.Log("checkposition1 " + checkposition1 + " ?=?  transform.position " + transform.position);
        Debug.Log("checkposition2 " + checkposition2 + " ?=?  transform.position " + transform.position);
        for (int i = 0; i < сentipedeObjects.Length; i++)// let's check if there is a centipade body in the path of the centipede
        {
            if (сentipedeObjects[i].transform.position.x == checkposition.x && сentipedeObjects[i].transform.position.y == checkposition.y)
            {
                Debug.Log("gameObjects[i].transform.position " + сentipedeObjects[i].transform.position);
                Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Inside there is the mushroom there");

                isexists = true;
            }
            //and check 2 nearest way, to use it then
            if (сentipedeObjects[i].transform.position.x == checkposition1.x && сentipedeObjects[i].transform.position.y == checkposition1.y)
            {
                isfreedirection1 = false;
            }
            if (сentipedeObjects[i].transform.position.x == checkposition2.x && сentipedeObjects[i].transform.position.y == checkposition2.y)
            {
                isfreedirection2 = false;
            }
        }


        if (isexists)//there is the mushroom there
        {// what direction chiise to centipede move?

            Debug.Log("++++++++another wayr++++++++++++++");

            if (!isfreedirection1 && !isfreedirection2)//Game over or new level or recriate centipede
            {
                Debug.Log("++++++++Game over++++++++++++++");
              //  Loader.ShowButton();
            }


            if (mydirection == "right")//if it wanted to go right,  but couldn’t. we change direction
            {
                if (isfreedirection1)
                {
                    direction = "left";
                    return -1;
                    //checkposition1
                }
                else if (isfreedirection2)
                {
                    ifDown = true;
                    return -1;
                }
            }
            else if (mydirection == "left")//if it wanted to go left, but couldn’t. we change direction
            {
                if (isfreedirection1)
                {
                    direction = "right";
                    return -1;
                    //checkposition1
                }
                else if (isfreedirection2)
                {
                    ifDown = true;
                    return -1;
                }
            }
            else if (mydirection == "down")//if it wanted to go down, but couldn’t. we change direction
            {
                if (isfreedirection1)
                {
                    direction = "left";
                    return -1;
                    //checkposition1
                }
                else if (isfreedirection2)
                {
                    direction = "right";
                    return -1;
                }
            }

         
        }
        else// all is good and centipade go ahead
        {
            Debug.Log("Inside there is not  the mushroom there");
            return 0;
        }
        return 0;


    }

    private bool IsCentipedeBodyExistsThere(string mydirection)
    {
        сentipedeObjects = GameObject.FindGameObjectsWithTag("snakehead");
        bool isexists = false;
        Vector3 checkposition = new Vector3(transform.position.x, transform.position.y);//create the vector to save position and change some parameters

        if (mydirection == "left")// cange corresponding coordinates
        {
            checkposition.x = checkposition.x - 1;           
        }
        if (mydirection == "right")// cange corresponding coordinates
        {
            checkposition.x = checkposition.x + 1;            
        }
       

        Debug.Log("checkposition " + checkposition + " ?=?  transform.position " + transform.position);
     
        for (int i = 0; i < сentipedeObjects.Length; i++)// let's check if there is a centipade body in the path of the centipede
        {
            if (сentipedeObjects[i].transform.position.x == checkposition.x && сentipedeObjects[i].transform.position.y == checkposition.y)
            {
                Debug.Log("gameObjects[i].transform.position " + сentipedeObjects[i].transform.position);
                Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Inside there is the mushroom there");

                return true;
            }
        }
        return false;
    }
    private int CanIGoThere(string mydirection)// is the next cell free?
    {    
        
        mushroomsObjects = GameObject.FindGameObjectsWithTag("mushroom");
        bool isexists = false;
        Vector3 checkposition = new Vector3(transform.position.x, transform.position.y);//create the vector to save position and change some parameters

        Vector3 checkposition1 = new Vector3(transform.position.x, transform.position.y);//for 2 nearest way
        Vector3 checkposition2 = new Vector3(transform.position.x, transform.position.y);
        bool isfreedirection1 = true;// check if the path is clear
        bool isfreedirection2 = true;// check if the path is clear

        if (mydirection == "left")// cange corresponding coordinates
        {
            checkposition.x = checkposition.x - 1;
            checkposition1.x += 1;//right
            checkposition2.y -= 1;//down
        }
        if (mydirection == "right")// cange corresponding coordinates
        {
            checkposition.x = checkposition.x + 1;
            checkposition1.x -= 1;//left
            checkposition2.y -= 1;//down
        }
        if (mydirection == "down")// cange corresponding coordinates
        {
            checkposition.y = checkposition.y - 1;
            checkposition1.x += 1;//right
            checkposition2.x -= 1;//left
        }
    
        Debug.Log("checkposition " + checkposition + " ?=?  transform.position " + transform.position);
        Debug.Log("checkposition1 " + checkposition1 + " ?=?  transform.position " + transform.position);
        Debug.Log("checkposition2 " + checkposition2 + " ?=?  transform.position " + transform.position);
        for (int i = 0; i < mushroomsObjects.Length; i++)// let's check if there is a mushroom in the path of the centipede
        {          
            if (mushroomsObjects[i].transform.position.x == checkposition.x && mushroomsObjects[i].transform.position.y == checkposition.y)
            {
                Debug.Log("gameObjects[i].transform.position " + mushroomsObjects[i].transform.position);
                Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Inside there is the mushroom there");             

                isexists = true;
            }
            //and check 2 nearest way, to use it then
            if (mushroomsObjects[i].transform.position.x == checkposition1.x && mushroomsObjects[i].transform.position.y == checkposition1.y)
            {
                isfreedirection1 = false;
            }
            if (mushroomsObjects[i].transform.position.x == checkposition2.x && mushroomsObjects[i].transform.position.y == checkposition2.y)
            {
                isfreedirection2 = false;
            }
        }


        if (isexists)//there is the mushroom there
        {// what direction chiise to centipede move?

            Debug.Log("++++++++another wayr++++++++++++++");

            if (!isfreedirection1 && !isfreedirection2)//Game over or new level or recriate centipede
            {
                Debug.Log("++++++++Game over++++++++++++++");
                // GameHandler.ShowButton() ;

                button.SetActive(true);
                GameHandler.StopeGame();
               // Time.timeScale = 0f;
                return -1;
                //Loader.ShowButton();
            }


            if (mydirection == "right")//if it wanted to go right,  but couldn’t. we change direction
            {
                if (isfreedirection1)
                {
                   
                    direction = "left";
                   
                }
                else if (isfreedirection2)
                {
                    ifDown = true;
                    return -1;
                }
            }
            else if (mydirection == "left")//if it wanted to go left, but couldn’t. we change direction
            {
                if (isfreedirection1)
                {
                    direction = "right";
                    return -1;

                  
                }
                else if (isfreedirection2)
                {
                    ifDown = true;
                    return -1;
                }
            } else if (mydirection == "down")//if it wanted to go down, but couldn’t. we change direction
            {
                if (isfreedirection1)
                {
                    direction = "left";
                    return -1;
                    //checkposition1
                }
                else if (isfreedirection2)
                {
                    direction = "right";
                    return -1;
                }
            }

        }
        else// all is good and centipade go ahead
        {
            Debug.Log("Inside there is not  the mushroom there");
            return 0;
        }
        return 0;

    }







        



    private void GoDown()
    {
      
        gridMoveDirection.x = 0;
        gridMoveDirection.y = -7;

     

        gridPosition += gridMoveDirection;
    
        transform.position = new Vector3(gridPosition.x, gridPosition.y);
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) + 90);


        if (direction == "right")// set direction
        {
           
            direction = "left";
        }
        else if (direction == "left")
        {
           
            direction = "right";
        }
    }
   
    void OnTriggerEnter2D(Collider2D o)
    {
      

        if (o.gameObject.tag == "mushroom")// if object collide with another that have some tag
        {
            Debug.Log("mushroom , direction " + direction);
        

            if (goDown == 0) // go down
            {
                ifDown = true;
            }



        }
        else if (o.gameObject.tag == "wall")// if object collide with another that have some tag
        {
            Debug.Log("wall , direction " + direction);
          
            if (goDown == 0)// go down
            {
                ifDown = true;
            }
        }
        else if (o.gameObject.tag == "bullet")// if object collide with another that have some tag
        {
            Debug.Log("bullet");
            Vector3 pos = gameObject.transform.position;
            Quaternion rot = gameObject.transform.rotation;

            Destroy(gameObject);
            GameObject bulletGO = (GameObject)Instantiate(mashroomPrefab, pos, rot);

            if (IsCentipadeDie())// if Centipade die
            {

                //Game over                  
              
                    Time.timeScale = 0f;

                    pauseWindow.SetActive(true);
                    youwin.SetActive(true);
                
              
            }
        }
       
        else if (o.gameObject.tag == "bottom")// if object collide with another that have some tag
        {
            //Game over 
            Debug.Log("Game over");
                Time.timeScale = 0f;

                pauseWindow.SetActive(true);
                youlose.SetActive(true);
            
          
           
        }
        else if (o.gameObject.tag == "player") // if object collide with another that have some tag
        {
          
            //Game over 
                Debug.Log("Game over");
                Time.timeScale = 0f;

                pauseWindow.SetActive(true);
                youlose.SetActive(true);
            
         
        }
    }

    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }
        return n;
    }



  
}
