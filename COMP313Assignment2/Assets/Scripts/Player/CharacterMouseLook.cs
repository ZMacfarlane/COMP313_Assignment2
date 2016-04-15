﻿using UnityEngine;
using System.Collections;

public class CharacterMouseLook : MonoBehaviour {

    public float xSpeed = 250.0f;
    private float x = 0.0f;

    // Use this for initialization
    void Start () {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
        Quaternion rotation = Quaternion.Euler(0, x, 0);
        transform.rotation = rotation;
    }
}
