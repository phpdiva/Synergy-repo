using UnityEngine;
using System.Collections;

public class CloudSystem : MonoBehaviour
{
    public GameObject cloud;
    public float cloudSpeed = 1;
    public int layer = 0;
    public float opacity = 1.0f;
    public float scale = 1.0f;
    public int cloudMax = 5;
    public int cloudMin = 1;
    public float maxHeight = 14;
    public float minHeight = 7;
    public int maxWidth = 22;
    public int minWidth = -10;

    [HideInInspector]
    public int cloudNum = 0;

    private int spawnBoundary = 20; //this will change to 0 after intialisation to stop clouds spawning in on screen

    public Vector3 randPosition
    {
        get
        {
            return new Vector3(Random.Range(minWidth, spawnBoundary), Random.Range(minHeight, maxHeight), layer);
        }
    }

    private void Awake()
    {
        int startingClouds = Random.Range(cloudMin, cloudMax);

        for (int i = 0; i <= startingClouds; i++)
        {
            AddCloud();
        }
        spawnBoundary = 0;//set to 0 for future spawning clouds in game
    }

    private void AddCloud()
    {
        GameObject newCloud = (GameObject)Instantiate(cloud, randPosition, Quaternion.identity);
        newCloud.transform.parent = this.transform;
        cloudNum++;
        CloudSetUp(newCloud);
    }

    public void CloudSetUp(GameObject cloudObj)
    {
        cloudObj.transform.position = randPosition;
        int randNumb = Random.Range(1, 4);
        cloudObj.gameObject.GetComponent<AnimateSprite>().SetFrameSet(randNumb.ToString());//the number it takes is the exact frame ont he sheet not a number inpalce of the usual name

        Vector3 individualScale;
        //set scale scale for particular cloud
        switch (randNumb)
        {
            case 1:
                {
                    individualScale = new Vector3(0.63f, 1, 1);
                    break;
                }

            case 2:
                {
                    individualScale = new Vector3(1.53f, 1.06f, 1);
                    break;
                }

            case 3:
                {
                    individualScale = new Vector3(7.1f, 3.36f, 1);
                    break;
                }
            case 4:
                {
                    individualScale = new Vector3(2.8f, 2.9f, 1);
                    break;
                }
            case 5:
                {
                    individualScale = new Vector3(5.56f, 3.3f, 1);
                    break;
                }
            case 6:
                {
                    individualScale = new Vector3(4.46f, 4.3f, 1);
                    break;
                }
            case 7:
                {
                    individualScale = new Vector3(2.66f, 1.83f, 1);
                    break;
                }
            case 8:
                {
                    individualScale = new Vector3(4.73f, 2.8f, 1);
                    break;
                }
            default:
                {
                    individualScale = new Vector3(1, 1, 1);
                    break;
                }
        }
        cloudObj.transform.localScale = individualScale; //sets individual
        cloudObj.transform.localScale = cloudObj.transform.localScale * scale; //set overall scale
    }

}
