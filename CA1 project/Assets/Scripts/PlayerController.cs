using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Declaring variables
    private AudioSource playerAudio;
    private Animator playerAnim;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] float speed = 10.0f;
    [SerializeField] Text astronautsCounterText;
    private int astronautsCounter = 0;
    private float horizontalInput;

    //cache references
    SceneLoader sceneLoader;

    private void Start()
    {
        //referencing components
        astronautsCounterText.text = astronautsCounter.ToString();
        sceneLoader = FindObjectOfType<SceneLoader>();
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    //method which allow the movement of the player
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.down * speed * Time.deltaTime * horizontalInput);
    }

    // method to manage the collisions whithin the palyer
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid")) //collision with the asteroids
        {
            playerAudio.PlayOneShot(deathSFX, 1f);
            playerAnim.SetTrigger("collision");

            StartCoroutine(WaitToLoad()); //starting a courotine method  
        }
        else if (collision.gameObject.CompareTag("Astronaut")) //collision with the astronauts
        {
            Destroy(collision.gameObject);
            astronautsCounter++;  //adding the number of astronauts 
            astronautsCounterText.text = astronautsCounter.ToString(); //showing the number of astronauts on the UI element
        }
    }

    //courotine method to load the next scene 1.2f seconds after the player died
    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(1.2f);
        sceneLoader.LoadNextScene();
    }
}
