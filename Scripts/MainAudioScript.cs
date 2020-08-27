using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioScript : MonoBehaviour
{
    public AudioSource gaudio;

    // Start is called before the first frame update
    public void UnmuteSound(){
        gaudio.volume = 1;
    }

    public void Awake()
    {
        gaudio.volume = 1;
    }

    public void MuteSound(){
        gaudio.volume = 0;
    }
}
