using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    private Vector2 paddleToBallVector;
    private bool hasStarted = false;
    [SerializeField] AudioClip[] ballSounds;

    AudioSource ballAudioSource;

    Vector2 tweakVelocity = new Vector2(0.1f, 0.2f);

    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        ballAudioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 15f);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length - 1)];
            ballAudioSource.PlayOneShot(clip);
            rigidBody.velocity += tweakVelocity;

            
        }
    }
}
