using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HelicopterMove.gameOver){
            StartCoroutine(WaitForGuiPanel());
        }
    }

     void Awake(){
         gameOverPanel.SetActive(false);
    }

    private IEnumerator WaitForGuiPanel()
    {
        yield return new WaitForSeconds (0.6f);
        gameOverPanel.SetActive(true);
    }
}
