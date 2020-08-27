using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMove : MonoBehaviour
{
    private bool enter = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy airplanes when they get out of screen play
         if(transform.position.x < -75){
            Destroy(gameObject);
        }
        transform.Translate(-0.5f, 0.0f, 0.0f, Space.World);
    }

    private void OnTriggerEnter(Collider other){
        // Trigger coin pickup function if a helicopter collides with this
        if(enter){
            Destroy(gameObject);
            other.transform.parent.GetComponent<HelicopterMove>().CopterCrash();
        }
    }
}
