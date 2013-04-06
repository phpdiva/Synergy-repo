using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
    public GameObject GameManagerPrefab;
    private void Awake()
    {
        //Gives the prefab attached to it to the manager to create itself
        //Debug.Log("Before Main calls GameManagerC.gameManagerObject = gameManager;");
        GameManagerC.gameManagerTemplate = GameManagerPrefab;
        //Debug.Log("After Main calls GameManagerC.gameManagerObject = gameManager;");
    }
}
