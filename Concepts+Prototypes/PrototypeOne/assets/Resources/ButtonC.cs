//MenueButton class.
//Casts rays from mouse pos and interects with the object that the user clicked on.
using UnityEngine;
using System.Collections;

public class ButtonC : MonoBehaviour
{
	//private bool gameMenu = false;
	
	public GameObject button;
	GameObject [] newButton = new GameObject[3];
	
	//private Vector3 position = new Vector3(300,300,0);

	// Update is called once per frame
	void Update()
	{
		CheckButtons();
		
		if (newButton[1]!= null)
		{
			Debug.Log("first update"+newButton[0].name);
			Debug.Log("first update"+newButton[1].name);
		}
	}
	
	void CheckButtons()
	{
		if (Input.GetMouseButtonUp(0)) //check for the mouse left click
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //send ray cast from mouse pos
			RaycastHit hit;
		      
			if (Physics.Raycast(ray, out hit)) //if the raycast collides
			{	
				GameObject selected = hit.collider.gameObject;
				
				if (selected.tag == ("Button"))
				{
					switch (Application.loadedLevelName)
					{
					case ("MainMenu"):
						switch (selected.name)
						{
						case ("PlayButton"):
							Application.LoadLevel("LevelSelection");
							break;
						case ("OptionsButton"):
							Application.LoadLevel("Options");
							break;
						case ("MuteButton"):
							Debug.Log("Mute");
							break;
						}
						break;
			
					case ("LevelSelection"):
						switch (selected.name)
						{
						case ("Level1Button"):
							Application.LoadLevel("01Level");
							break;
						case ("Level2Button"):
							Application.LoadLevel("02Level");
							break;
						case ("BackButton"):
							Application.LoadLevel("MainMenu");
							break;
						case ("MuteButton"):
							Debug.Log("Mute");
							break;
						}
						break;
			
					case ("Options"):
						switch (selected.name)
						{
						case ("PlayButton"):
							Application.LoadLevel("LevelSelection");
							break;
						case ("OptionsButton"):
							Application.LoadLevel("Options");
							break;
						case ("MuteButton"):
							Debug.Log("Mute");
							break;
						}
						break;
			
					default:
						switch (selected.name)
						{
						case ("GameMenuButton"):
							print("GameMenuButton");
							InstantiateGameMenuButtons();
							//Time.timeScale = 0;
							break;
							
						case ("ContinueButton"):
							//detroy buttons and unpause
							//Application.LoadLevel(Application.loadedLevelName);
							Debug.Log("ContinueButton");
							break;
							
						case ("MainMenuButton"):
							Application.LoadLevel("MainMenu");
							Debug.Log("MainMenuButton");
							break;
							
						case ("RestartLevelButton"):
							Application.LoadLevel(Application.loadedLevelName);
							Debug.Log("RestartLevelButton");
							break;
							
						default:
							print(selected.name);
							Debug.Log("fsjklghjakdghjdhgjkadgf");
							break;
						}

						break;
					}
				}
			}
		}
	}
	
	public void InstantiateGameMenuButtons()
	{
		//newButton[0] = (GameObject) Instantiate(button, new Vector3(0,0,0), Quaternion.identity);
		newButton[0] = (GameObject) Instantiate(Resources.Load("Button"));
		Debug.Log("before" + newButton[0].name);
		newButton[0].name = "ContinueButton";
		newButton[0].tag = "Button";
		Debug.Log("after" + newButton[0].name);
		newButton[0].transform.Translate(0,100,0);
		
		
		newButton[1] = (GameObject) Instantiate(Resources.Load("Button"));
		//newButton[1] = (GameObject) Instantiate(button, new Vector3(0,0,0), Quaternion.identity);
		Debug.Log("before" + newButton[1].name);
		newButton[1].name = "MainMenuButton";
		newButton[1].tag = "Button";
		Debug.Log("after" + newButton[1].name);
		newButton[1].transform.Translate(0,50,0);
//		
//		newButton[2] = (GameObject) Instantiate(button, new Vector3(0,0,0), Quaternion.identity);
//		newButton[2].name = "RestartLevelButton";
//		newButton[2].tag = "Button";
//		newButton[2].transform.Translate(0,0,0);
		

		
		//Debug.Log("got to end"+newButton[2].name);
		
		//Debug.Log(newButton.position);
		//Debug.Log(position);
	}
	
	void CheckGameMenuButtons()
	{
		if (Input.GetMouseButtonUp(0)) //check for the mouse left click
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //send ray cast from mouse pos
			RaycastHit hit;
		      
			if (Physics.Raycast(ray, out hit)) //if the raycast collides
			{	
				GameObject selected = hit.collider.gameObject;
				
				if (selected.tag == ("Button"))
				{
					
				}
			}
		}
	}

}
