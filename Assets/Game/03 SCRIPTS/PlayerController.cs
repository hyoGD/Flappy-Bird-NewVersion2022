using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private CircleCollider2D _cir;

    [SerializeField] Animator _anim;

    [Header("Value")]
    [SerializeField] float _force;
    // Start is called before the first frame update
    void Start()
    {
        this._rb = GetComponent<Rigidbody2D>();
        this._cir = GetComponent<CircleCollider2D>();

        _anim.SetBool("Moving", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instant.IsLose) return;
        MovingPlayer();
    }

    public void MovingPlayer()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.Instant.IsUI)
        {
            _rb.AddForce(new Vector2(0, _force));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CheckPoin"))
        {
            GameManager.Instant.AddScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _anim.SetBool("Moving", false);
            GameManager.Instant.Lose();
        }
    }
}
