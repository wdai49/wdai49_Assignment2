using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Text scoreText;
    int score;
    int point;
    bool isDetected;

    public int Point
    {
        set { point = value; }
        get { return point; }
    }
  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
    }


     void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);

    }

    void OnTriggerEnter(Collider collision)
    {
        isDetected = false;
        if (collision.gameObject.tag == "green")
        {
            Point= 1;
            isDetected = true;
        }
        else if (collision.gameObject.tag == "magenta")
        {
            Point= 10;
            isDetected = true;
        }
        else if(collision.gameObject.tag=="red")
        {
            Point= 100;
            isDetected = true;
        }

        if (isDetected)
        {
            score += Point;
            Destroy(collision.gameObject);
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
