using UnityEngine;
using System.Collections;

public class BulletGrenade : MonoBehaviour {

	float makeBulletDisappear = 3.0f;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		makeBulletDisappear -= Time.deltaTime;
		if(makeBulletDisappear <= 0){
			destroy();
		}
	}
	void destroy()
	{
		Destroy (gameObject);
	}
}
