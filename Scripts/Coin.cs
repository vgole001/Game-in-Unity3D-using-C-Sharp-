using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] objs;
        objs = Physics.OverlapSphere(transform.position + Vector3.up, 2.0f);
        foreach(Collider c in objs){
            if(c.name == "Building1(Clone)" || c.name == "Building2(Clone)"){
                Destroy(gameObject);
            }
        }

        if(transform.position.x < -75){
            Destroy(gameObject);
        }
        transform.Translate(-Building.speed, 0.0f, 0.0f,Space.World);
        //Rotate coin in y axis
        transform.Rotate(0.0f, 0.5f, 0.0f, Space.World);
        //isColliding = false;

        //Destroy Coins left after game is over
        if(HelicopterMove.gameOver == true || HelicopterMove.win == true){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other){
        // trigger coin pickup function if a helicopter collides with this
        if(!isColliding){
            isColliding = true;
            other.transform.parent.GetComponent<HelicopterMove>().PickupCoin();
            Destroy(gameObject);
        }
    }
}
