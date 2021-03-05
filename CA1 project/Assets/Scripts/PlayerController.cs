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
        astronautsCounterText.text = astronautsCounter.ToString();
        sceneLoader = FindObjectOfType<SceneLoader>();
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.down * speed * Time.deltaTime * horizontalInput);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            playerAudio.PlayOneShot(deathSFX, 1f);
            playerAnim.SetTrigger("collision");

            StartCoroutine(WaitToLoad());
        }
        else if (collision.gameObject.CompareTag("Astronaut"))
        {
            Destroy(collision.gameObject);
            astronautsCounter++;
            astronautsCounterText.text = astronautsCounter.ToString();
        }
    }

    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(1.2f);
        sceneLoader.LoadNextScene();
    }
}
