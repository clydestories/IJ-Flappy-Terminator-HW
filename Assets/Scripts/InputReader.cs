using System;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private List<KeyCode> JumpKeys;
    [SerializeField] private List<KeyCode> ShootKeys;
    
    public event Action Jumped;
    public event Action<Vector2> Shot;

    private void Update()
    {
        foreach (KeyCode key in JumpKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Jumped?.Invoke();
                break;
            }
        }

        foreach (KeyCode key in ShootKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Shot?.Invoke(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                break;
            }
        }
    }
}
