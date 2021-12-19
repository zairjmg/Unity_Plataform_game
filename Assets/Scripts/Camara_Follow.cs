using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Follow : MonoBehaviour
{
    public GameObject _player;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = _player.transform.position.x;
        transform.position = pos;
    }
}
