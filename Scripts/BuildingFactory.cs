using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFactory : MonoBehaviour
{
    public GameObject[] selectorArr;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBuildings());
    }

    // Update is called once per frame
    void Update()
    {
        if(Building.destroyedBuilding == true){
            Destroy(gameObject);
        }
    }

    private IEnumerator SpawnBuildings() {
    while(true){
            GameObject go = Instantiate(selectorArr[Random.Range(0, selectorArr.Length)], new Vector3(80.0f, -25, 41.0f),
            Quaternion.Euler(0f,-90f, 0f)) as GameObject;
            //wait 1 to 5 secs before generating new coins
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }
}
