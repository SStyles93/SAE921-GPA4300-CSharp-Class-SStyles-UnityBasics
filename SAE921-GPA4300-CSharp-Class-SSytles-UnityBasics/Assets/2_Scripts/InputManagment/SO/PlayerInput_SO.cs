using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInputProfile", menuName ="PlayerInput")]
public class PlayerInput_SO : ScriptableObject
{
    [Tooltip("\"Vector2\" from User input, used for movement")]
    [SerializeField] public Vector3 movement;
    [Tooltip("\"Vector2\" from User input, used for rotation")]
    [SerializeField] public Vector3 rotation;
    [Tooltip("Bool from User input, used for an action (Fire)")]
    [SerializeField] public bool fire;
    [Tooltip("Bool from User input, used for an action (Jump)")]
    [SerializeField] public bool jump;
}
