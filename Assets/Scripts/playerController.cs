using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

    public GameObject _gameOverScreen;
    public float speed = 5.0f;
    public float JumpPower = 5.0f;
    [SerializeField] private Rigidbody2D _rb;
    public bool _isGrounded = true;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _offsetX = 1f;
    [SerializeField] private int _life;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        Jump();
        Fire();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, JumpPower);
            _isGrounded = false;
        }
    }

    void Fire()
    {
        Vector3 firePositionOffset = new Vector3((_offsetX), 0, 0);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(_bullet, transform.position + firePositionOffset, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }

        if (collision.gameObject.tag == "Goal")
        {
            Time.timeScale = 0;
            _gameOverScreen.SetActive(true);
        }


        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.manager.TakeLife(_life);
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
