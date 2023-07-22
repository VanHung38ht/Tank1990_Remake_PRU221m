using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using System;

public class fileStorage : TankCreateMap
{
    private string filePath = "Assets/StreamingAssets/dataCreateMap.csv"; // thu muc luu tru vi tri cac block
    public GameObject menuOption, optionOne;
    StreamWriter writer = null;
    StreamReader reader = null;
    bool skipHeader = true;

    private void Update()
    {
        if (saveFile.savefile)
        {
            Time.timeScale = 0;
            savemap();

            menuOption.SetActive(true);
            //Clear Object selected
            EventSystem.current.SetSelectedGameObject(null);
            // Choose a new selected object
            EventSystem.current.SetSelectedGameObject(optionOne);

            saveFile.savefile = false;
        }
    }

    // Start is called before the first frame update
    void savemap()
    {
        GameObject[] treeObject = GameObject.FindGameObjectsWithTag("tree");    //tim kiem cac object tree
        GameObject[] blockObject = GameObject.FindGameObjectsWithTag("block");  //tim kiem cac object block
        GameObject[] rockObject = GameObject.FindGameObjectsWithTag("rock");    //tim kiem cac object rock
        GameObject[] waterObject = GameObject.FindGameObjectsWithTag("water");

        try
        {
            using (writer = new StreamWriter(filePath))    //ghi data vao file csv
            {
                writer.WriteLine("Gameobject, X,Y,Z");  //tieu de code

                //ghi du lieu vi tri object tree vao tung dong
                foreach (GameObject tree in treeObject)
                {
                    Vector3 positiontree = tree.transform.position; // vi tri cac object tree
                    writer.WriteLine($"{1},{positiontree.x},{positiontree.y},{positiontree.z}");    //ghi ten, vi tri x,y,z vao file
                    Destroy(tree);
                }

                //ghi du lieu vi tri object block vao tung dong
                foreach (GameObject block in blockObject)
                {
                    Vector3 positionblock = block.transform.position; // vi tri cac object block
                    writer.WriteLine($"{2},{positionblock.x},{positionblock.y},{positionblock.z}");    //ghi ten, vi tri x,y,z vao file
                    Destroy (block);
                }

                //ghi du lieu vi tri object rock vao tung dong
                foreach (GameObject rock in rockObject)
                {
                    Vector3 positionrock = rock.transform.position; // vi tri cac object rock
                    writer.WriteLine($"{3},{positionrock.x},{positionrock.y},{positionrock.z}");    //ghi ten, vi tri x,y,z vao file
                    Destroy(rock);
                }

                foreach (GameObject water in waterObject)
                {
                    Vector3 positionwater = water.transform.position; // vi tri cac object rock
                    writer.WriteLine($"{4},{positionwater.x},{positionwater.y},{positionwater.z}");    //ghi ten, vi tri x,y,z vao file
                    Destroy(water);
                }
            }
        }
        catch   (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            if (writer != null)
            {
                writer.Close();
            }
        }
        
        
    }

    public void loadMap()
    {
        try
        {
            reader = new StreamReader(filePath);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (skipHeader)
                {
                    skipHeader = false;
                    continue;
                }

                string[] values = line.Split(',');

                int type = int.Parse(values[0]);
                float x = float.Parse(values[1]);
                float y = float.Parse(values[2]);
                float z = float.Parse(values[3]);

                if (type == 1)
                {
                    Instantiate(tree, new Vector3(x, y, z), Quaternion.identity);
                }
                else if (type == 2)
                {
                    Instantiate(Block, new Vector3(x, y, z), Quaternion.identity);
                }
                else if (type == 3)
                {
                    Instantiate(Rock, new Vector3(x, y, z), Quaternion.identity);
                }
                else if (type == 4)
                {
                    Instantiate(water, new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
            }
        }

    }
}
