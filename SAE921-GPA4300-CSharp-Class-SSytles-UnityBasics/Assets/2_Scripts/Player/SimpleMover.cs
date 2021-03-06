using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    [Header("Script References")]
    //private PlayerInput playerInput;
    [Tooltip("Link the Scripts corresponding to the name field")]
    [SerializeField] private PlayerInputSystem playerInput;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerInput_SO playerInputSO;
    [Header("Player stats")]
    [Tooltip("Player's speed value in meters/seconds")]
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
        ////Default version
        //gameObject.transform.Translate(playerInput.movement * speed * Time.deltaTime);
        //gameObject.transform.Rotate(playerInput.rotation * speed * Time.deltaTime);
        //if (playerInput.jump)
        //{
        //    animator.Play("Jump");
        //    playerInput.jump = false;
        //}

        //SO version
        gameObject.transform.Translate(playerInputSO.movement * speed * Time.deltaTime);
        gameObject.transform.Rotate(playerInputSO.rotation * speed * Time.deltaTime);
        if (playerInputSO.jump)
        {
            animator.Play("Jump");
            playerInputSO.jump = false;
        }
    }
}
