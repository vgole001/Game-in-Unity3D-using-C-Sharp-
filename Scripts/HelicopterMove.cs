using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//using UnityEngine.SceneManagement;

public class HelicopterMove : MonoBehaviour
{
    private Rigidbody rb;
    private float vertical,horizontal;
    public float sensitivity = 25.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float minY = -22.0f;
    private float maxY = 8.0f;
    private float negX = -40.0f;
    private float posX = 60.0f;
        
    public int coinsCollected = 0;
   	public AudioSource explosionSound;

    public AudioSource winningSound;
       
    private UIController UI;
    private ConfettiPlay confetti;

    public GameObject explosionEffect;
    //public GameObject winningEffect;

    public GameObject GUI_WHAT;

    public static bool gameOver = false;

    public static bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        win = false;
        gameOver = false;
        rb = GetComponent<Rigidbody>();
        UI = GameObject.FindObjectOfType(typeof(UIController)) as UIController;
        confetti = GameObject.FindObjectOfType(typeof(ConfettiPlay)) as ConfettiPlay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetAxis("Vertical") != 0){
            //Increment vertical movement based on sensitivity
            vertical = Input.GetAxis("Vertical") * sensitivity;
            //Check for vertical bounds 
            if (transform.position.y < minY) {
				transform.position = new Vector3(transform.position.x, minY, transform.position.z);
			}
			if (transform.position.y > maxY) {
				transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
            }
        }
        else{
            vertical = 0f;
        }
        if(Input.GetAxis("Horizontal") != 0){
            if (transform.position.x < negX) {
				transform.position = new Vector3(negX, transform.position.y, transform.position.z);
			}
            if (transform.position.x > posX) {
				transform.position = new Vector3(posX, transform.position.y, transform.position.z);
			}
            //Increment horizontal movement based on sensitivity
            horizontal = Input.GetAxis("Horizontal") * sensitivity;            
            //Clamp the vertical angle between minimum and maximum limits
            horizontal = Mathf.Clamp(horizontal, minimumVert, maximumVert);
            //Keep the same Y angle (i.e no horizontal rotation)
            float rotationY = transform.localEulerAngles.y;
            //Create a new vector from the stored rotation
            transform.localEulerAngles = new Vector3(horizontal, rotationY, 0);
        }
        else{
            horizontal = 0f;
        }
        rb.velocity = new Vector3(horizontal, vertical, 0);
    }

    public void PickupCoin() {
        coinsCollected += 1;
        GetComponents<AudioSource>()[0].Play();
        UI.updateCoinsOnUI(coinsCollected);
	}

    public void CopterCrash(){
        win = false;
        GameObject explosParticle = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        explosionSound.Play();
        Destroy(explosParticle, 1.0f);       
        GameOver();
    }

    public void CopterWin(){
        win = true;
        //GameObject winningEffectObj = (GameObject)Instantiate(winningEffect, transform.position, transform.rotation);
        confetti.displayConfetti();
        winningSound.Play();
        //Destroy(explosParticle, 1.0f);       
        GameOver();
    }

    public void GameOver ()
    {
        gameOver = true;
        Destroy(gameObject);
    }
}