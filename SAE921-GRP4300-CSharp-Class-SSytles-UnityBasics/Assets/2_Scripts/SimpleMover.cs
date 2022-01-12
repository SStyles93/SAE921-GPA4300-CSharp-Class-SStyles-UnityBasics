using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    //private PlayerInput playerInput;
    [SerializeField] private PlayerInputSystem playerInput;
    [SerializeField] float speed = 10.0f;

    private void Awake()
    {
        //playerInput = GetComponent<PlayerSystem>();
        playerInput = GetComponent<PlayerInputSystem>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        gameObject.transform.Translate(playerInput.movement * speed * Time.deltaTime);
    }
}
