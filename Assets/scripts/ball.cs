using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PaddleController paddle1;
    Vector2 paddletoballvector;
    bool HasSTarted = false;
    [SerializeField] float  velocityx = 2f;
    [SerializeField] float velocityy = 15f;
    [SerializeField] AudioClip[] ballsounds;
    AudioSource Myaudiosource;
    [SerializeField] float RandomFactor;
    Rigidbody2D myRigidbodyd;
    bool BallLaunched = false;

    void Start()
    {
        paddletoballvector = transform.position - paddle1.transform.position;
        Myaudiosource = GetComponent<AudioSource>();
        myRigidbodyd = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        LockBallToPaddle();
        LaunchBallOnMouseClick();
    }

    // Update is called once per frame
    void LockBallToPaddle()
    {

        if (!HasSTarted)
        {
            Vector2 paddlepos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlepos + paddletoballvector;
            
        }

    }
    public void LaunchBallOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (BallLaunched == false)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(velocityx, velocityy);
                HasSTarted = true;
                BallLaunched = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 VelocityTweak = new Vector2(Random.Range(0f, RandomFactor),Random.Range(0f,RandomFactor));
        if (HasSTarted)
        {
            AudioClip clip = ballsounds[Random.Range(0, ballsounds.Length)];
            Myaudiosource.PlayOneShot(clip);
            myRigidbodyd.velocity += VelocityTweak;

        }
    }
}
