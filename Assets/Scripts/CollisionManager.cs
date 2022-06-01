
using System;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private SpawnManager _spawnManager;

    [SerializeField] private GameObject _spawn = default;

    private void Start()
    {
        _spawn = GameObject.FindGameObjectWithTag("Spawn");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
           _spawn.GetComponent<SpawnManager>().CreatingNPCelite();
           Destroy(gameObject);
        }
       
    }
}
