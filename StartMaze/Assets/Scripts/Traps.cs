using UnityEngine;
using System.Collections;

public class Traps : MonoBehaviour {
	public float delayTime;
	// Use this for initialization
	public AudioClip spikeNoise;

	void Start () {
		StartCoroutine(Go());
	}
	
	IEnumerator Go()
	{
		while(true)
		{
			animation.Play();
			AudioSource.PlayClipAtPoint(spikeNoise, transform.position);
			yield return new WaitForSeconds(3f);

		}


	}
}
