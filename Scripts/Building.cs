using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    //public float PlayerOnexPos;
    Coin other;
    public static float speed = 0.3f;
    private bool enter = true;
    public static bool destroyedBuilding;
    // Start is called before the first frame update
    void Start()
    {
        destroyedBuilding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -75f){
            Destroy(gameObject);
        }
        transform.Translate(-speed, 0.0f, 0.0f, Space.World);
        //Destroy Buildings left after game is over
        if(HelicopterMove.gameOver == true || HelicopterMove.win == true){
            StartCoroutine(WaitBeforeDestroy());
        }
        if(destroyedBuilding == true){
            Destroy(gameObject);
        }
    }

     private void OnTriggerEnter(Collider other){
        // Trigger coin pickup function if a helicopter collides with this
        if(enter){
            transform.Rotate(0.0f, 0.0f, -5.0f, Space.World);
            other.transform.parent.GetComponent<HelicopterMove>().CopterCrash();
        }
    }

    private IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds (3.0f);
        Destroy(gameObject);
        destroyedBuilding = true;
    }
}

