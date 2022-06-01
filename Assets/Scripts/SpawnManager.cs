using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{   
    [SerializeField] private GameObject Elite = default;
    [SerializeField] private GameObject Player1 = default;
    [SerializeField] private GameObject Player2 = default;

    [Header("Transforms")]
    [SerializeField] private Transform[] EliteSpawns = null;
    [SerializeField] private float Score = 0;
    [SerializeField] private float lastScore = 0;

    private void Awake()
    {
        var player1 = PlayerInput.Instantiate(prefab: Player1, playerIndex: 0, controlScheme : "Keyboard2" , pairWithDevice: Keyboard.current, splitScreenIndex: 0);
        var player2 = PlayerInput.Instantiate(prefab: Player2, playerIndex: 1,  controlScheme : "Keyboard1", pairWithDevice: Keyboard.current, splitScreenIndex: 1);
    }
    
    private void AddScore()
    {
        lastScore = Score;
        Score++;
    }

    public void CreatingNPCelite()
    {
        int _randomState = Random.Range(0, 5);
        Instantiate(Elite, EliteSpawns[_randomState].position, Quaternion.identity);
    }
}
