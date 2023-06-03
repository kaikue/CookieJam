using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [SerializeField] private GameObject _playerBody;
    private Rigidbody2D rb;
    private Animator playerAnimator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = _playerBody.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector2 vel = new Vector2(xInput, yInput).normalized * speed;

        if (Mathf.Abs(xInput) > 0 || Mathf.Abs(yInput) > 0)
        {
            playerAnimator.SetBool("IsWalking", true);
        } else
        {
            playerAnimator.SetBool("IsWalking", false);
        }

        rb.MovePosition(rb.position + vel * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col);
        PlayerManager.Instance.Evolve(PlayerManager.EvolutionState.SWIM);
        if (col.gameObject.tag == "Water")
        {
            Destroy(gameObject);
        }
    }

}
