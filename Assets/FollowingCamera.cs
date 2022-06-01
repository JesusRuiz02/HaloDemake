using System.Globalization;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player = default;
    public Vector3 _offset = default;
    [SerializeField] private bool _playerOne = true;

    private void Start()
    {
        var typePlayer = _playerOne ? "Player" : "Enemy";
        _player = GameObject.FindGameObjectWithTag(typePlayer);
        transform.position = new Vector3(_player.transform.position.x + _offset.x, _player.transform.position.y + _offset.y, _offset.z);
    }

    void Update()
    {
        transform.position = new Vector3( _player.transform.position.x + _offset.x, _player.transform.position.y + _offset.y, _offset.z);
    }
}
