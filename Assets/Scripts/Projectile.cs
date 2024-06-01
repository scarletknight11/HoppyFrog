using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 5.0f;


    // Update is called once per frame
    void Update()
    {
        MoveForward();
        CheckBoundary();
    }

    void MoveForward()
    {
        //float translation = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * 10 * speed * Time.deltaTime);
    }

    void CheckBoundary()
    {
        if (transform.position.x > 10)
        {
            Destroy(this.gameObject);
        }
    }
}
