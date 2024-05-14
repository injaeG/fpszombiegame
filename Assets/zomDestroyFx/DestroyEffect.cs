using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {


	void Start () {
		Destroy (gameObject, 0.5f);
		GetComponent<AudioSource> ().Play ();
	}


	void Update () {
	
	}
}
