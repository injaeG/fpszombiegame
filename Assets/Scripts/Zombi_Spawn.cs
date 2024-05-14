using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Zombi_Spawn : MonoBehaviour {

	public GameObject prefabZombi;
	public GameObject[] zombi = new GameObject[20];
	public Transform[] points;
	bool isGameover = false;


	void Start () {

		points = GameObject.Find ("ZomPointGrp").GetComponentsInChildren<Transform> ();

		for (int i = 0; i < zombi.Length; i++) 
		{
			zombi[i] = Instantiate (prefabZombi, transform.position, Quaternion.identity)as GameObject;
			zombi[i].SetActive (false);
		}
			
		StartCoroutine (SpawnZombi());
	}
		


	IEnumerator SpawnZombi(){

		while (!isGameover) {

			yield return new WaitForSeconds (3.0f);

			foreach (GameObject obj in zombi) {

				if (obj.activeSelf == false) {

					int location = Random.Range (0, points.Length);
					obj.transform.position = points[location].position;	
					obj.SetActive (true);
					break;

				}
			}
		}
	}
		
}

