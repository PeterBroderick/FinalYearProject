using UnityEngine;
using System.Collections;

public class Aknowlegments : MonoBehaviour {
	public GameObject text;
	public GameObject camera2;
	public int speed = 10;
	public string level;

	void Update () {	
		text.transform.Translate(0, 0.08f,0);
		camera2.transform.Translate(0, 0.005f,0);
	}
	
	IEnumerator waitFor(){
		yield return new WaitForSeconds (5);
		Application.LoadLevel (level);
	}
}
