﻿using UnityEngine;

public class CameraPlayerMovement : MonoBehaviour
{
    public float MyTime, cameraOfset;
	private GameManager gameManager;
	
	void Start()
	{
		gameManager = FindObjectOfType<GameManager>(); 
	}

    // Update is called once per frame
	void Update ()
	{    
		var player = gameManager.GetLeadingPlayer();
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, player.transform.position.z-cameraOfset);
	}
}