using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour
{
    private void Start()                            //calls on start to avoid issues with being called before aniamtion component awake function
    {
        string rock = Random.Range(1, 4).ToString();
        gameObject.GetComponent<AnimateSprite>().SetFrameSet(rock);
    }
}
