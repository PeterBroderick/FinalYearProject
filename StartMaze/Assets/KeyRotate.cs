using UnityEngine;
using System.Collections;

public class KeyRotate : MonoBehaviour {

	void Update(){

		transform.Rotate (new Vector2 (90, 0) * Time.deltaTime);
	}
}
