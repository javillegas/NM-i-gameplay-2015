﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngineInternal;

public class GameManager : MonoBehaviour {

	public GameObject MapRoot;

	private Player leadingPlayer;

	private List<Player> players;
	private List<KeyCode> leftCodes;
	private List<KeyCode> rightCodes;
	private int 
		direction = 1;
	public List<Player> Players
	{
		//NOTE: Gets new players once, then stores it
		get { return players ?? (players = FindObjectsOfType<Player>().ToList()); }
	}

	public List<KeyCode> LeftKeyCodes
	{
		get { return leftCodes ?? (leftCodes = players.Select(player => player.leftKeyCode).ToList()); }
	}

	public List<KeyCode> RightKeyCodes
	{
		get { return rightCodes ?? (rightCodes = players.Select(player => player.rightKeyCode).ToList()); }
	}

	void Awake()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		foreach (var player in players)
		{
			if (leadingPlayer == null)
				leadingPlayer = player;
			if (direction>0)
			{
				if (leadingPlayer.transform.position.x < player.transform.position.x)
					leadingPlayer = player;
			}
			else
			{
				if (leadingPlayer.transform.position.x > player.transform.position.x)
					leadingPlayer = player;
			}
		}
	}

	private void ReverseAllPlayers(float pivotPointX)
	{
		direction *= -1;
		foreach (var player in players)
		{
			player.SetReverseDirection();
		}
		//TODO iTween map around pivotPoint
	}
	public void IhitReverseAll(float pos)
	{
		ReverseAllPlayers(pos);
	}

	public Player GetLeadingPlayer()
	{
		return leadingPlayer;
	}


	
}
