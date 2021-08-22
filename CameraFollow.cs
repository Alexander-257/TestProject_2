using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 cameraDistance;

    void Start() {

    }

    void Update() {
        transform.position = player.transform.position + cameraDistance;
    }
}
