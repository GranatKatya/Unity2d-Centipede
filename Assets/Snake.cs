
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    public GameObject snakeBodySprite;
 //   public Sprite snakeBodySprite;

    private Vector2Int gridMoveDirection;// right direction
    private Vector2Int gridPosition;
    private string direction = "right";
    //  private float gridMoveTimer;
    //  private float gridMoveTimerMax;
    private int snakeBodySize;
    private List<Vector2Int> snakeMovePositionList;
    private List<SnakeBodyPart> snakeBodyPartList;



    public float period = 0.0f;

    private void Awake()
    {
        gridPosition = new Vector2Int(49, 56);
      //  gridMoveTimerMax = 0.1f;//1 second
      //  gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1,0);// move to right 

        snakeMovePositionList = new List<Vector2Int>();
        snakeBodySize = 5;
        snakeBodyPartList = new List<SnakeBodyPart>();
        for (int i = 0; i < snakeBodySize; i++)
        {
            CreateSnakeBody();//test
        }

    }



    private void Update()
    {

        if (period > 0.1)
        { 
            if (direction == "right")
            {
                gridMoveDirection.x = +4;
                gridMoveDirection.y = 0;
             //   gridPosition.x += 1;//right
            }
            //if (direction == "down")
            //{
            //    gridPosition.y -= 1;
            //}
            if (direction == "left")
            {
                gridMoveDirection.x = -4;
                gridMoveDirection.y = 0;
               // gridPosition.x -= 1;
            }


            //if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
            //{
            //    pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
            //}
            //if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
            //{
            //    pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
            //}
            //float screenRatio = (float)Screen.width / (float)Screen.height;
            //float widhtOrtho = Camera.main.orthographicSize * screenRatio;
            //if (pos.x + shipBoundaryRadius > widhtOrtho)
            //{
            //    pos.x = widhtOrtho - shipBoundaryRadius;
            //}
            //if (pos.x - shipBoundaryRadius < -widhtOrtho)
            //{
            //    pos.x = -widhtOrtho + shipBoundaryRadius;
            //}




            //gridMoveTimer += Time.deltaTime;
            //if (gridMoveTimer >= gridMoveTimerMax)
            //{
            //    gridPosition += gridMoveDirection;
            //    gridMoveTimer -= gridMoveTimerMax;
            //}
            
            snakeMovePositionList.Insert(0, gridPosition);

            gridPosition += gridMoveDirection;
            if (snakeMovePositionList.Count >= snakeBodySize+1)
            {
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count-1);//to remove end
            }

            //for (int i = 0; i < snakeMovePositionList.Count; i++)
            //{
            //    Vector2Int snakeMovePosition = snakeMovePositionList[i];
            //    World_Sprite ws = World_Sprite.Create(new Vector3(snakeMovePosition.x, snakeMovePosition.y), Vector3.one * .5f, Color.white);
            //    FunctionTimer.Create(ws.DestroySelf, 0.01f);
            //}  

            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0,0, GetAngleFromVector(gridMoveDirection)-90);

            UpdateSnakeBodyPart();
           

            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
    }


    void OnTriggerEnter2D(Collider2D o)
    {
      //  Debug.Log("mushro222om!");
     //   || o.gameObject.tag == "wall"
        if (o.gameObject.tag == "mushroom")
        {
           snakeBodySize++;//test  
            CreateSnakeBody();//test

          //  Debug.Log("!mu12shroom!");

          //  gridPosition.y -= 1;//down
            gridMoveDirection.x =  0;
            gridMoveDirection.y = -6;

            snakeMovePositionList.Insert(0, gridPosition);

            gridPosition += gridMoveDirection;
            if (snakeMovePositionList.Count >= snakeBodySize + 1)
            {
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);//to remove end
            }


        //    gridPosition += gridMoveDirection;
            transform.position = new Vector3(gridPosition.x, gridPosition.y)  ;
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) +90);

            UpdateSnakeBodyPart();

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
        else if(o.gameObject.tag == "wall")
        {
            gridMoveDirection.x = 0;
            gridMoveDirection.y = -8;

            snakeMovePositionList.Insert(0, gridPosition);

            gridPosition += gridMoveDirection;
            if (snakeMovePositionList.Count >= snakeBodySize + 1)
            {
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);//to remove end
            }


            //    gridPosition += gridMoveDirection;
            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) + 90);

            UpdateSnakeBodyPart();

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
    }

    private float GetAngleFromVector( Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        if (n<0)
        {
            n += 360;
        }
        return n;
    }

    private void CreateSnakeBody() {
        snakeBodyPartList.Add(new SnakeBodyPart(snakeBodyPartList.Count, snakeBodySprite));
    }
    private void UpdateSnakeBodyPart()
    {
        for (int i = 0; i < snakeBodyPartList.Count; i++)
        {
           // Vector3 snakeBodyPosition = new Vector3(snakeMovePositionList[i].x, snakeMovePositionList[i].y);
            // snakeBodyPartList[i].position = snakeBodyPosition;
            snakeBodyPartList[i].SetGridPosition(snakeMovePositionList[i]);
        }
    }


    private class SnakeBodyPart {

        private Vector2Int gridPosition;
        private Transform transform;
        public SnakeBodyPart(int bodyIndex, GameObject snakeBodySprite)
        {
            GameObject snakeBodeGameObject = (GameObject)Instantiate(snakeBodySprite);//, transform.position + offset, transform.rotation);

         //   GameObject snakeBodeGameObject =  new GameObject("SnakeBody", typeof(SpriteRenderer));

          //  snakeBodeGameObject.GetComponent<SpriteRenderer>().sprite = snakeBodySprite;
            //  snakeMoveTransformList.Add(snakeBodeGameObject.transform);
            // snakeBodeGameObject.GetComponent<SpriteRenderer>().sortingOrder = -snakeMoveTransformList.Count;
            snakeBodeGameObject.GetComponent<SpriteRenderer>().sortingOrder = -bodyIndex;
            transform = snakeBodeGameObject.transform;
        }

        public void SetGridPosition(Vector2Int gridPosition)
        {
          //  gridPosition.x +=  -2;
            this.gridPosition = gridPosition;
            transform.position = new Vector3(gridPosition.x , gridPosition.y);
        }
    }
}
