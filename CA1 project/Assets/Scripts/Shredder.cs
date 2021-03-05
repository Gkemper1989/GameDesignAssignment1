using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script to destroy the game objects which are not on the scene anymore

public class Shredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
