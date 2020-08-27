using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftFactory : MonoBehaviour
{
    public int gameObjects = 2;

    public GameObject[] selectorArr;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAircrafts());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAircrafts() {
    while(true){
			GameObject go = Instantiate(selectorArr[Random.Range(0, selectorArr.Length)], new Vector3(82.0f, Random.Range(3,8), 40.0f),
             Quaternion.Euler(0f,-90f, 0f)) as GameObject;
            //Wait 5 to 10 secs before generating new coins
			yield return new WaitForSeconds(Random.Range(6, 9));
		}
    }
}
