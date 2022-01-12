using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] float speed = 0.01f;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        gameObject.transform.Translate(playerInput.NewPos * speed);
    }
}
