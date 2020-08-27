using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
   public GameObject selector;
	//float oldRandom = 0.0f;
	//float newRandom = 0.0f;

	// Use this for initialization
	void Start () {
	
		// call SpawnCoins for generating new coins
		StartCoroutine(SpawnCoins());
	}

	// Update is called once per frame
	void Update () {

	}

	public IEnumerator SpawnCoins() {
		while(true){

			// number of coins 
			//int coinsThisRow = Random.Range(1, 3);
			/*for (int i = 0; i < 3; i++) {
				//newRandom = Random.Range(-10,5);
				/* while(newRandom == oldRandom){
					newRandom = Random.Range(-10,5);
					if(newRandom != oldRandom && ((Mathf.Abs(newRandom - oldRandom)) > 2.3f)) {
						break;
					}
					else{
						oldRandom = newRandom;
						continue;
					}
					//if(newRandom != oldRandom) break;
				}*/
				/*Random.InitState(1);
				float x = Random.Range(1, 3);
				Random.InitState(2);
				float y = Random.Range(1, 3);

				GameObject go = Instantiate(selector, new Vector3(70.0f, x , 40.0f), Quaternion.identity) as GameObject;
				oldRandom = newRandom;			
		}*/
		Random rnd = new Random();

			GameObject go = Instantiate(selector, new Vector3(70.0f, Random.Range(-10.0f,0.0f) , 40.0f), Quaternion.identity) as GameObject;
			GameObject go1 = Instantiate(selector, new Vector3(70.0f, Random.Range(2.0f,5.0f) , 40.0f), Quaternion.identity) as GameObject;

			//wait 1 to 5 secs before generating new coins
			yield return new WaitForSeconds(Random.Range(2, 5));
		}
	}
}
