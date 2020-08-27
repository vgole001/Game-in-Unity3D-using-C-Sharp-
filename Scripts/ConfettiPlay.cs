using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiPlay : MonoBehaviour
{
    public GameObject winningEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void displayConfetti(){
        GameObject winningEffectObj = (GameObject)Instantiate(winningEffect, transform.position, transform.rotation);
    }
}
