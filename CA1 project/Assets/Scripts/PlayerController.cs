using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
  
    private AudioSource playerAudio;
    private Animator playerAnim;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] float speed = 10.0f;
    private float horizontalInput;

    //cache
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
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
        playerAudio.PlayOneShot(deathSFX, 1f);
        playerAnim.SetTrigger("collision");
       
        StartCoroutine(WaitToLoad());
    }

    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(1.2f);
        sceneLoader.LoadNextScene();
    }
}
