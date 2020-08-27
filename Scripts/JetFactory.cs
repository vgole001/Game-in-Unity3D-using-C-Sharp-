using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetFactory : MonoBehaviour
{
   public GameObject selector;

	// Use this for initialization
	void Start () {

		// call SpawnCoins for generating new coins
		StartCoroutine(SpawnJet());
	}

	// Update is called once per frame
	void Update () {

	}

	private IEnumerator SpawnJet() {
		while(true){
			// number of coins 
			GameObject go = Instantiate(selector, new Vector3(26.0f, 19, Random.Range(44,72)), Quaternion.Euler(45f,0f, 0f)) as GameObject;
			//wait 1 to 5 secs before generating new coins
			yield return new WaitForSeconds(Random.Range(15, 20));
		}
	}
}
