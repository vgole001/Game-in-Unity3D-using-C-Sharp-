using UnityEngine;
using System.Collections;

public class AnimateBackground : MonoBehaviour {

    public float animationRate = 0.05f;
    protected float _uvOffset = 0.0f;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {
		// Time.time is time since the game began, vs. deltaTime, which is time since last frame
		_uvOffset = (_uvOffset + animationRate * (Time.deltaTime * (float)2.0));
        rend.material.mainTextureOffset = new Vector2(_uvOffset, 0.0f);
	}
}
