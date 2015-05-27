using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
		
		public GUIStyle customButton;
		public GUIStyle customButton2;
		public GUIStyle customButton3;
		public GUIStyle header;
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		void OnGUI()
	{
		  GUI.Button (new Rect (Screen.width/2 - 100, 150, 300, 50), "The Adventures of Milan", header);
			
		if(GUI.Button (new Rect (Screen.width/2 - 100,250,300,50), "Start Game", customButton)) {
				
				StartGame();
				
			}
			
		if (GUI.Button (new Rect (Screen.width/2 - 100, 350, 300, 50), "Load Credits", customButton3)) {
				
				Credits();//This is actuall quit button
			}
			
			
		if (GUI.Button (new Rect (Screen.width/2 - 100, 450, 300, 50), "Exit", customButton2)) {
				
				Exit();//This is actuall quit button
			}
			
			
			
			
			
			
			
			
		}
		
		void StartGame(){
			Application.LoadLevel("NearlyThere");
		}

		void Credits(){
			Application.LoadLevel("CreditsFinal");
		}
		
		void Exit(){
			Application.Quit();
		}
}

