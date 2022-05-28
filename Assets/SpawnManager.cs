using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
    [SerializeField] private GameObject Elite = default;

    [Header("Transforms")]
    [SerializeField] private Transform[] EliteSpawns = null;
    [SerializeField] private float Score = 0;
    [SerializeField] private float lastScore = 0;

    void Update()
    {
        if (lastScore < Score)
        {
            
        }
    }

    private void AddScore()
    {
        lastScore = Score;
        Score++;
    }

    private void CreatingNPCelite()
    {
        int _randomState = Random.Range(0, 5);
        Instantiate(Elite, EliteSpawns[_randomState].position, Quaternion.identity);
    }
}
