using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] AudioClip[] ballSounds;

    private Vector2 paddleToBall;
    bool hasStarted = false;

    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddle.transform.position;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) {
            LockBalOnPaddle();
            LaunchBallOnClick();
        }
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f );
            hasStarted = true;
        }
    }

    void LockBalOnPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted) {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
             _audioSource.PlayOneShot(clip);
        }
    }

}
