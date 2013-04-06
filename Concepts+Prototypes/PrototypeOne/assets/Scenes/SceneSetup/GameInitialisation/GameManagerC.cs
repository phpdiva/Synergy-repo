using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerC : MonoBehaviour
{
	public List <GameObject> collisionList = new List <GameObject> ();
	private static GameManagerC instance;
	
	public static float xMinBoundary = 0.0f;
	public static float yMinBoundary = 0f;
	public static float zMinBoundary = 0f;
	public static float xMaxBoundary = 900f;
	public static float yMaxBoundary = 540f;
	public static float zMaxBoundary = 0f;
	private int gameid = 939617;
	private string guid = "0ef58d05b6604549";
	private string apikey = "d1eefd40adb54627a20888c61adccf";
	private string NextLevel;
	private GameObject musicManager;

	public static GameManagerC Instance
	{
		get
		{	
			//if no instance exists create one by filling it with the game object that holds the script
			if (!instance)
			{
				instance = (GameManagerC)GameObject.FindObjectOfType(typeof(GameManagerC));
 				
				//if there is no container then make a new one
				if (!instance)
				{
					GameObject container = new GameObject ();
					container.name = "GlobalsC";
					instance = (GameManagerC)container.AddComponent(typeof(GameManagerC));
				}
			}
 
			return instance;
		}	
	}
	
	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		} else
		{
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	void Start()
	{
		musicManager = GameObject.Find("MusicManager");
		//Playtomic.Initialize(gameid, guid, apikey);
		//Playtomic.Log.View();
	}

	void Update()
	{
//		for (int i = 0; i < collisionList.Count-1; i ++)
//		{
//			for (int j = i+1; j < collisionList.Count; j ++)
//			{
//				if (Vector3.Distance(collisionList [i].transform.position, collisionList [j].transform.position) < 10)
//				{
//					
//					print("halelluyah");
//					
//				}
//			}
//		}
		if (Input.GetButton("R"))
		{
			ReloadLevel();
		}
		
		if (Input.GetButton("1"))
		{
			LoadLevel(1);
		}
		
		if (Input.GetButton("2"))
		{
			LoadLevel(2);
		}
	}
	
	
	void ReloadLevel()
	{
		Application.LoadLevel(Application.loadedLevelName);
		musicManager.SendMessage("ChangeTrack");
	}
	
	void LoadGameMenu()
	{
		//return to game
		//options
		//back to main menu
		//restat game
	}
	
	void LoadLevel(int levelToLoad)
	{
		if (levelToLoad<10)
		{
			NextLevel = "0"+ levelToLoad +"Level";
		}
		else
		{
			NextLevel = levelToLoad+"Level";
		}
		
		Application.LoadLevel(NextLevel);
		musicManager.SendMessage("ChangeTrack");
	}
	
	public static Vector3 GetMinBoundary()
	{
		
		return new Vector3 (xMinBoundary, yMinBoundary, zMinBoundary); 
	}
	
	public static Vector3 GetMaxBoundary()
	{
		return new Vector3 (xMaxBoundary, yMaxBoundary, zMaxBoundary); 
	}
}


