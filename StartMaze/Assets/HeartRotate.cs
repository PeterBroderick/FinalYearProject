using UnityEngine;
using System.Collections;

public class HeartRotate : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector2 (10, 90) * Time.deltaTime);
	}
}
