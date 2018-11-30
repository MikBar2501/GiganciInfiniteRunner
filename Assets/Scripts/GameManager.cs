﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public float worldScrollingSpeed;

	public Text scoreText;

	private float score;

	public GameObject obstacle;

	public float obstacleSpawnRate;
	public float maxObstacleSpawnHeight, minObstacleSpawnHeight;
	public float obstacleSpawnPositionX;
	public bool inGame;
	public GameObject resetButton;

	

	// Use this for initialization
	void Start () {
		instance = this;
		InvokeRepeating("SpawnObstacle", obstacleSpawnRate, obstacleSpawnRate);
	}
	
	private void FixedUpdate() {
		if(!GameManager.instance.inGame) {
			return;
		} else {
			score += worldScrollingSpeed;
			UpdateScreenScore();
		}		
	}

	void UpdateScreenScore() {
		scoreText.text = score.ToString("0");
	}

	void SpawnObstacle() {
		var spawnPosition = new Vector3(obstacleSpawnPositionX, Random.Range(minObstacleSpawnHeight, maxObstacleSpawnHeight), 0f);
		Instantiate(obstacle, spawnPosition, Quaternion.identity);
	}



}
