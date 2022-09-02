using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputSource : MonoBehaviour
{
    public Vector3Int Input { get; private set; }
    public bool Active => Input != Vector3Int.zero;

    void Update()
    {
        GetInput();

        Debug.Log(Input);
    }

    private void GetInput()
    {
        if (UnityEngine.Input.GetKey(KeyCode.LeftArrow)) Input = new Vector3Int(0, 0, 1);
        else if (UnityEngine.Input.GetKey(KeyCode.RightArrow)) Input = new Vector3Int(0, 0, -1);
        else if (UnityEngine.Input.GetKey(KeyCode.UpArrow)) Input = new Vector3Int(1, 0, 0);
        else if (UnityEngine.Input.GetKey(KeyCode.DownArrow)) Input = new Vector3Int(-1, 0, 0);
        else Input = Vector3Int.zero;
    }
}
