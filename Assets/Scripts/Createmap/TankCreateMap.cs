using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TankCreateMap : intruct
{
    public GameObject tree;     //khai bao gameobject tree
    public GameObject Block;    //khai bao gameobject gach
    public GameObject Rock;     //khai bao gameobject da
    public GameObject water;

    float sizeX = (float)(7.68f / 0.32);    //size man hinh tinh theo so gameobject ton tai trong game theo chieu ngang
    float sizeY = (float)(4.8f / 0.32);     //size man hinh tinh theo so gameobject ton tai trong game theo chieu doc
    float x;        
    float y;
    int offsetX;
    int offsetY;
    float createTime = 0.1f;    //thoi gian de tao moi block(Gameobject)
    GameObject[,] gameObjectsArray;     //khai bao mang de luu tru gameobject
    GameObject emptyObject;

    public static class saveFile
    {
        public static bool savefile = false;
    }

    void Start()
    {
        gameObjectsArray = new GameObject[(int)(sizeX * 2), (int)(sizeY * 2)];    //khai bao so phan tu trong mang

        emptyObject = new GameObject();     //tao mot empty gameobject

        for (int i = 0; i < (int)(sizeX * 2); i++)
        {
            for (int j = 0; j < (int)(sizeY * 2); j++)
            {
                gameObjectsArray[i, j] = emptyObject;     //gan empty gameobject cho cac phan tu trong mang
            }
        }
    }

    void Update()
    {
        if (!GameStatus.isGamePaused && GameStatus.isTankCreate)       //xet game co dang puase ko, neu pause, ko the input cac keycode
        {
            setTrigger(Block);
            setTrigger(Rock);
            setTrigger(water);
            tree.transform.SetSiblingIndex(0);

            if (createTime < 0.2)
            {
                createTime += Time.deltaTime;   //dem time cho phep dat block
            }

            if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.J)) && (createTime > 0.15))
            {
                createTime = 0;     //reset thoi gian cho cho phep dat blcok

                // vi tri dat block
                x = (float)((int)(transform.position.x / 0.32) * 0.32);
                y = (float)((int)(transform.position.y / 0.32) * 0.32);

                // vi tri gameobject trong mang
                offsetX = (int)(Mathf.RoundToInt(x / 0.32f) + sizeX);
                offsetY = (int)(Mathf.RoundToInt(y / 0.32f) + sizeY);

                //destroy object tai vi tri offsetX, offsetY
                Destroy(gameObjectsArray[offsetX, offsetY]);

                if ((offsetX, offsetY) == (20, 2) || (offsetX, offsetY) == (8, 27) || (offsetX, offsetY) == (15, 24) || (offsetX, offsetY) == (40, 27) || (offsetX, offsetY) == (33, 24))
                {
                    return;
                }

                // tao ra block moi
                gameObjectsArray[offsetX, offsetY] = Instantiate(tree, new Vector3(x, y, 0), Quaternion.identity);
            }

            if ((Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.K)) && (createTime > 0.15))
            {
                createTime = 0;

                // vi tri dat block
                x = (float)((int)(transform.position.x / 0.32) * 0.32);
                y = (float)((int)(transform.position.y / 0.32) * 0.32);

                // vi tri gameobject trong mang
                offsetX = (int)(Mathf.RoundToInt(x / 0.32f) + sizeX);
                offsetY = (int)(Mathf.RoundToInt(y / 0.32f) + sizeY);

                //destroy object tai vi tri offsetX, offsetY
                Destroy(gameObjectsArray[offsetX, offsetY]);

                if ( (offsetX, offsetY) == (20, 2) || (offsetX, offsetY) == (8, 27) || (offsetX, offsetY) == (15, 24) || (offsetX, offsetY) == (40, 27) || (offsetX, offsetY) == (33, 24))
                {
                    return;
                }

                // tao ra block moi
                gameObjectsArray[offsetX, offsetY] = Instantiate(Block, new Vector3(x, y, 0), Quaternion.identity);
            }

            if ((Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.L)) && (createTime > 0.15))
            {
                createTime = 0;

                // vi tri dat block
                x = (float)((int)(transform.position.x / 0.32) * 0.32);
                y = (float)((int)(transform.position.y / 0.32) * 0.32);

                // vi tri gameobject trong mang
                offsetX = (int)(Mathf.RoundToInt(x / 0.32f) + sizeX);
                offsetY = (int)(Mathf.RoundToInt(y / 0.32f) + sizeY);

                //destroy object tai vi tri offsetX, offsetY

                Destroy(gameObjectsArray[offsetX, offsetY]);

                if ((offsetX, offsetY) == (20, 2) || (offsetX, offsetY) == (8, 27) || (offsetX, offsetY) == (15, 24) || (offsetX, offsetY) == (40, 27) || (offsetX, offsetY) == (33, 24))
                {
                    return;
                }

                // tao ra block moi
                gameObjectsArray[offsetX, offsetY] = Instantiate(Rock, new Vector3(x, y, 0), Quaternion.identity);
            }

            if ((Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.U)) && (createTime > 0.15))
            {
                createTime = 0;

                // vi tri dat block
                x = (float)((int)(transform.position.x / 0.32) * 0.32);
                y = (float)((int)(transform.position.y / 0.32) * 0.32);

                // vi tri gameobject trong mang
                offsetX = (int)(Mathf.RoundToInt(x / 0.32f) + sizeX);
                offsetY = (int)(Mathf.RoundToInt(y / 0.32f) + sizeY);

                //destroy object tai vi tri offsetX, offsetY

                Destroy(gameObjectsArray[offsetX, offsetY]);

                if ((offsetX, offsetY) == (20, 2) || (offsetX, offsetY) == (8, 27) || (offsetX, offsetY) == (15, 24) || (offsetX, offsetY) == (40, 27) || (offsetX, offsetY) == (33, 24))
                {
                    return;
                }

                // tao ra block moi
                gameObjectsArray[offsetX, offsetY] = Instantiate(water, new Vector3(x, y, 0), Quaternion.identity);
            }

            if (Input.GetKey(KeyCode.Q)) 
            {
                returnSetTrigger(Block);
                returnSetTrigger(Rock);
                returnSetTrigger(water);
                tree.transform.SetSiblingIndex(3);
                
                saveFile.savefile = true;
                GameStatus.isTankCreate = false;
            }
        }
    }

    private void setTrigger(GameObject obj)
    {
        BoxCollider2D collider2D = obj.GetComponent<BoxCollider2D>();

        if (collider2D != null)
        {
            collider2D.isTrigger = true;
        }
        else
        {
            Debug.Log(collider2D);
        }
    }

    private void returnSetTrigger(GameObject obj)
    {
        BoxCollider2D collider2D = obj.GetComponent<BoxCollider2D>();

        if (collider2D != null)
        {
            collider2D.isTrigger = false;
        }
        else
        {
            Debug.Log(collider2D);
        }
    }
}
