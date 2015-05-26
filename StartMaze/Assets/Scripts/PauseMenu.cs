using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	public GUISkin myskin;
	public GUIStyle customButton;
	public GUIStyle customButton1;
	private Rect windowRect;
	private bool paused = false , waited = true, option = false, control = false;
	public Texture2D textureToDisplay;

	private void Start()
	{
		windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 300);
		AudioListener.pause = false;
		
	}
	
	private void waiting()
	{
		waited = true;
	}
	
	private void Update()
	{
		if (waited)
			if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.P))
		{
			Screen.lockCursor = false;
			GameObject.Find("Player").GetComponent<FirstPersonController>().enabled=false;
			GameObject.Find("GunBarrelEnd").GetComponent<PlayerShooting>().enabled=false;
			
			if (paused)
				
				paused = false;
			else
				paused = true;
			
			waited = false;
			Invoke("waiting",0.3f);
		}
		if (paused)
		{
			Time.timeScale = 0;	
			
		} 
		else 
		{
			Time.timeScale = 1;	
		}
	}
	
	void OnGUI()
	{
		if (paused)
			
			windowRect = GUI.Window(0, windowRect, windowFunc, "Pause Menu",customButton1);
		//GameObject.Find("GunBarrelEnd").GetComponent<FirstPersonController>().enabled=false;
		
		if (option) 
		{
			windowRect = GUI.Window(0, windowRect, windowFuncOption, "Option",customButton1);
			//paused = false;
			
			
		}
		
		if (control) {
			windowRect = GUI.Window(0, windowRect, windowFuncControl, "Control",customButton1);
			GUI.Label(new Rect(Screen.width/4, Screen.height / 2 , textureToDisplay.width, textureToDisplay.height),textureToDisplay);			
			Debug.Log("jhgjhgjh");
		}
	}
	
	private void windowFunc(int id)
	{
		if (GUILayout.Button("Resume",customButton))
		{
			GameObject.Find("Player").GetComponent<FirstPersonController>().enabled=true;
			GameObject.Find("GunBarrelEnd").GetComponent<PlayerShooting>().enabled=true;
			paused = false;
			Screen.lockCursor = true;
		}
		if (GUILayout.Button("Options",customButton))
		{
			option = true;
			//paused = false;
			
			
		}
		if (GUILayout.Button("Player Controls",customButton))
		{
			control = true;
			//paused = false;
			
			
		}
		if (GUILayout.Button("Quit",customButton))
		{
			Application.LoadLevel("MenuMain");
		}
	}
	
	private void windowFuncOption(int id)
	{
		if (GUILayout.Button("Audio On",customButton))
		{
			AudioListener.pause = false;
			option = false;
			paused = true;
			
		}
		if (GUILayout.Button("Audio Off",customButton))
		{
			AudioListener.pause = true;
			option = false;
			paused = true;
			
		}
		
	}
	
	
	private void windowFuncControl(int id)
	{
		if (GUILayout.Button("Back",customButton))
		{
			
			control = false;
			paused = true;
			
		}
		
	}
	
	
	
	
	
	
}