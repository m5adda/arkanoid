using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public float speed = 10.5f;
    public GameObject scoreText;
    int totalscore;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        // ascii art:
        //
        // 1  -0.5  0  0.5  1 <- x value
        //==================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "racket")
        {
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;

        }
        if(col.gameObject.name == "Square")
        {
            totalscore++;
            scoreText.GetComponent<TextMeshProUGUI>().text = totalscore.ToString();
        }
    }
 


}
