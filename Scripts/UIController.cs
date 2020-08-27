using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController: MonoBehaviour {

    private HelicopterMove hel;
    [SerializeField] public Text gameOverMsg;
    [SerializeField] public Text totalCoins;
    [SerializeField] public Text timeLeft;
    private MainAudioScript mainAudio;
    public bool muted = false;
    private ConfettiPlay confetti;
    private float Timer = 60;
    private int coinsToWin = 25;

    // Start is called before the first frame update
    void Start()
    {
        hel = GameObject.FindObjectOfType(typeof(HelicopterMove)) as HelicopterMove;
        mainAudio = GameObject.FindObjectOfType(typeof(MainAudioScript)) as MainAudioScript;
        gameOverMsg.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(hel != null){
            StartCoroutine(StartCountdown());
            timeLeft.text = Timer.ToString();
            timeLeft.text += "'";
            if(Timer < 10){
                timeLeft.color = new Color(255.0f/255.0f, 0.0f/255.0f, 0.0f/255.0f);
            }
            if(Timer < 1 && (hel.coinsCollected < coinsToWin)){
                hel.CopterCrash();
            }
            if(Timer > 1 && (hel.coinsCollected == coinsToWin)){
                hel.CopterWin();
            }
            totalCoins.text = hel.coinsCollected.ToString();
        }
         if(HelicopterMove.gameOver == true){
            if (HelicopterMove.win == false)
            {
                gameOverMsg.text = "Game Over!\n Your Score: " + totalCoins.text.ToString() + "/"+ coinsToWin + 
                    "\nPress Space To Restart!"+
                    "\nESC For Main Menu!";
                //StartCoroutine(PauseGame());
            }
            else
            {
                gameOverMsg.text = "Victory!\n Your Score: " + totalCoins.text.ToString() + "/"+ coinsToWin + 
                    "\nPress Space To Restart!"+
                    "\nESC For Main Menu!";
            }
            mainAudio.MuteSound();
            muted = true;
            if (Input.GetButtonDown("Jump")) {
                // Reload entire scene, starting music over again, refreshing score
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(1);  
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0); 
            }
        }          
    }    
    public void updateCoinsOnUI(int coins){
        totalCoins.text = coins.ToString();
    }

    public IEnumerator StartCountdown()
    {
        float tempTime = Timer;
        while (Timer >= 1)
        {
            yield return new WaitForSeconds(1.0f);
            tempTime--;
            Timer = tempTime;
        }
    }

    private IEnumerator PauseGame()
    {
        yield return new WaitForSeconds (3.0f);
        Time.timeScale = 0.0f;
    }
}
