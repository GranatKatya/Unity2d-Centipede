using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveSnakePrefab : MonoBehaviour
{



    public GameObject button;//retray button
    public GameObject pauseWindow;
    public GameObject youwin;
    public GameObject youlose;

    //public GameObject heardPrefab;
    //GameHandler GameHandler;

    public GameObject mashroomPrefab;
    // public GameObject snakeBodySprite;    

    private Vector2Int gridMoveDirection;// right direction
    private Vector2Int gridPosition;
    public string direction = "right";
    // public string previousdirection = "right";
    public int goDown = 0;
    // public int goRi = 10;
    //  public bool alowChange = true;
    public bool ifDown = false;



    //  private int snakeBodySize;
    // private List<Vector2Int> snakeMovePositionList;
    // private List<SnakeBodyPart> snakeBodyPartList;

    //[SerializeField]
    //private int xStartPosition;
    //[SerializeField]
    //private int yStartPsition;
    //[SerializeField]
    //private int zStartPsition;



    public float period = 0.0f;
    // public float period1 = 0.0f;



    //public GameObject respawnPrefab;
    //public GameObject[] respawns;
    GameObject[] mushroomsObjects;//array for objects with tag  "mushrooms"
    GameObject[] сentipedeObjects;// array for objects with tag  "snakehead"

    void Start()
    {
        сentipedeObjects = GameObject.FindGameObjectsWithTag("snakehead");
        //if (сentipedeObjects.Length == 0)
        //{
        //      Debug.Log("No game objects are tagged with 'snakehead'");
        //}
        //else
        //{
        //    Debug.Log("size of snakehead = " + сentipedeObjects.Length);
        //}
        mushroomsObjects = GameObject.FindGameObjectsWithTag("mushroom");

        //if (mushroomsObjects.Length == 0)
        //{
        //  //  Debug.Log("No game objects are tagged with 'Enemy'");
        //}
        //else
        //{
        //    Debug.Log("size of mushrooms = " + mushroomsObjects.Length);
        //}
        //for (int i = 0; i < gameObjects.Length; i++)
        //{
        //    Debug.Log(i + " gameObjects[i].transform.position  " + gameObjects[i].transform.position);
        //}


    }



    private void Awake()
    {
        gridPosition = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        gridMoveDirection = new Vector2Int(1, 0);// move to right 
        button.SetActive(false);
        //  button.SetActive(false);
        // snakeMovePositionList = new List<Vector2Int>();
        // snakeBodySize = 4;
        //  snakeBodyPartList = new List<SnakeBodyPart>();
        //for (int i = 0; i < snakeBodySize; i++)
        //{
        //    CreateSnakeBody();//test
        //}
        //  youwin = GameObject.Find("winbutton").GetComponent<GameObject>();
        youwin.SetActive(false);
        youlose.SetActive(false);
        //  pauseWindow = GameObject.Find("PauseWindow").GetComponent<GameObject>();
    }



    private void Update()
    {

        if (period > 0.5)
        {

            //if (IsCentipadeDie())//die
            //{

            //        Debug.Log("++++++++Game over die++++++++++++++");
            //        //   GameHandler.StopeGame();
            //        Time.timeScale = 0f;

            //        pauseWindow.SetActive(true);
            //        youwin.SetActive(true);

            //}


            if (ifDown)
            {
                int res = CanIGoThere("down");
                if (res == -1)
                {
                    ifDown = false;
                    return;
                }
                // if (direction == "dowm")
                //  {
                // if (direction == "down")
                // {
                // alowChange = false;

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





                //    //if (direction == "down" && goDown <= 0)
                //    //{

                //    if (previousdirection == "right")// set direction
                //    {
                //        //Debug.Log(" go to left now");
                //        // gridPosition.y -= 1;
                //        direction = "left";
                //    }
                //    else if (previousdirection == "left")
                //    {
                //        // Debug.Log(" go to right now ");
                //        // gridPosition.y -= 1;
                //        direction = "right";
                //    }
                //    //}


                //    // StartCoroutine(Foo());
                //    // }
                //    //IEnumerator Foo()
                //    //{
                //    //    // Do something
                //    //    yield return new WaitForSeconds(1f);  // Wait three seconds
                //    //                                          // Do something else
                //    //}
                //}


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
                    //   bool    IsCentipedeBodyExistsThere();
                    //Vector3 spawnPos = transform.position;
                    //spawnPos.x -= 2;
                    //Debug.Log(" spawnPos" + spawnPos);  
                    //if (Physics.CheckSphere(spawnPos, 1f))
                    //{
                    //    Debug.Log(" spawnPos.x  Return!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" + spawnPos.x);
                    //    return;

                    //}
                    //else
                    //{
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


            //TimeSpan ts = DateTime.Now + TimeSpan.FromSeconds(seconds);

            //do { } while (DateTime.Now < ts);

            ////snakeMovePositionList.Insert(0, gridPosition);
            //gridPosition += gridMoveDirection;
            ////if (snakeMovePositionList.Count >= snakeBodySize + 1)
            ////{
            ////    snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);//to remove end
            ////}


            //transform.position = new Vector3(gridPosition.x, gridPosition.y);
            //transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) - 90);

            ////    UpdateSnakeBodyPart();


            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
    }


    private bool IsCentipadeDie() // neeed to ckeck if there are parts of centipade or on
    {
        Debug.Log("IsCentipadeDie");
        //GameObject [] сentipede = null;
        // сentipedeObjects = null;
        сentipedeObjects = GameObject.FindGameObjectsWithTag("snakehead");

        if (сentipedeObjects.Length - 1 > 0)
        {
            // Debug.Log("сentipedeObjects.Length > 0 сentipedeObjects.Length " + сentipedeObjects.Length);
            return false;
        }
        else
        {
            // Debug.Log("сentipedeObjects.Length !> 0 сentipedeObjects.Length " + сentipedeObjects.Length);
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

            //if (direction == "right")
            //{
            //    direction = "left";
            //    return -1; ;
            //}
            //if (direction == "left")
            //{
            //    direction = "right";
            //    return -1;
            //}
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
                    //bool myres = IsCentipedeBodyExistsThere("left");
                    //if (!myres)
                    //{
                    //    direction = "left";
                    //    return -1;
                    //}
                    //else
                    //{
                    //    Debug.Log("++++++++Game !!!!!!!!!!!!!!!!!!!!!! over++++++++++++++");
                    //}
                    direction = "left";
                    //    return -1;

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

                    //bool myres = IsCentipedeBodyExistsThere("right");
                    //if (!myres)
                    //{
                    //    direction = "right";
                    //    return -1;
                    //}
                    //else
                    //{
                    //    Debug.Log("++++++++Game !!!!!!!!!!!!!!!!!!!!!! over++++++++++++++");
                    //}
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

            //if (direction == "right")
            //{
            //    direction = "left";
            //    return -1; ;
            //}
            //if (direction == "left")
            //{
            //    direction = "right";
            //    return -1;
            //}
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
        // snakeBodySize++;//test  
        //   CreateSnakeBody();//test

        //  Debug.Log("!mu12shroom!");

        //  gridPosition.y -= 1;//down
        gridMoveDirection.x = 0;
        gridMoveDirection.y = -7;

        //  snakeMovePositionList.Insert(0, gridPosition);

        gridPosition += gridMoveDirection;
        //if (snakeMovePositionList.Count >= snakeBodySize + 1)
        //{
        //    snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);//to remove end
        //}


        //    gridPosition += gridMoveDirection;
        transform.position = new Vector3(gridPosition.x, gridPosition.y);
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) + 90);

        //  UpdateSnakeBodyPart();

        if (direction == "right")// set direction
        {
            //Debug.Log(" go to left now");
            // gridPosition.y -= 1;
            direction = "left";
        }
        else if (direction == "left")
        {
            // Debug.Log(" go to right now ");
            // gridPosition.y -= 1;
            direction = "right";
        }
    }
    private void GoDownBy1()
    {

        //gridMoveDirection.x = 0;
        //gridMoveDirection.y = -1;
        ////  gridPosition.y -= 1;
        //gridPosition += gridMoveDirection;
        //transform.position = new Vector3(gridPosition.x, gridPosition.y);
        //transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) + 90);

        //if (previousdirection == "right")// set direction
        //{
        //    direction = "left";
        //}
        //else if (previousdirection == "left")
        //{
        //    direction = "right";
        //}
        //period1 = 0;

    }
    void OnTriggerEnter2D(Collider2D o)
    {
        //  Debug.Log("mushro222om!");
        //   || o.gameObject.tag == "wall"

        if (o.gameObject.tag == "mushroom")
        {
            Debug.Log("mushroom , direction " + direction);
            // GoDownBy1();

            //// GoDown();

            if (goDown == 0)
            {
                ifDown = true;
            }

            ////    direction = "down";


        }
        else if (o.gameObject.tag == "wall")
        {
            Debug.Log("wall , direction " + direction);
            //  GoDownBy1();

            if (goDown == 0)
            {
                ifDown = true;
            }
        }
        else if (o.gameObject.tag == "bullet")
        {
            Debug.Log("bullet");
            Vector3 pos = gameObject.transform.position;
            Quaternion rot = gameObject.transform.rotation;

            Destroy(gameObject);
            GameObject bulletGO = (GameObject)Instantiate(mashroomPrefab, pos, rot);

            if (IsCentipadeDie())//die
            {
                //    if (!ScoreWindow.RemoveLife()) {
                //  if (!ScoreWindow.IsGameOver())
                {
                    Debug.Log("++++++++Game over die++++++++++++++");
                    //   GameHandler.StopeGame();
                    Time.timeScale = 0f;

                    pauseWindow.SetActive(true);
                    youwin.SetActive(true);
                }
                //else
                //{
                //    Debug.Log("++++++++  die create ew !!!!!!!!!!! ++++++++++++++");
                //    //delete all centipade
                //    //  NewCentipede.DeleteCentipade();
                //    Debug.Log("++++++++  die create ew !!!!!!!!!!! ++++++++++++++");
                //    NewCentipede.CreateCentipade();
                //}               
            }
        }
        else if (o.gameObject.tag == "snakehead")
        {
            Debug.Log("snakehead");
            //WaitForSeconds();

            //if (direction == "left" || direction == "right")// check only next left (6-7) units 
            //{

            //    Vector3 for1 = o.gameObject.transform.forward;


            //}


        }
        else if (o.gameObject.tag == "bottom")
        {
            if (!ScoreWindow.RemoveLife())
            {
                Debug.Log("Game over");
                Time.timeScale = 0f;

                pauseWindow.SetActive(true);
                youlose.SetActive(true);
            }
            Destroy(gameObject);

            //try
            //{
            //    NewCentipede.DeleteCentipade();
            //    NewCentipede.CreateCentipade();
            //}
            //catch (System.Exception)
            //{
            //    Debug.Log("ERROR");
            //    //throw;
            //}

        }
        else if (o.gameObject.tag == "player")
        {
            if (!ScoreWindow.RemoveLife())
            {
                Debug.Log("Game over");
                Time.timeScale = 0f;

                pauseWindow.SetActive(true);
                youlose.SetActive(true);
            }
            Destroy(gameObject);
            //try
            //{
            //    NewCentipede.DeleteCentipade();
            //    NewCentipede.CreateCentipade();
            //}
            //catch (System.Exception)
            //{
            //    Debug.Log("ERROR");
            //    //throw;
            //}
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
