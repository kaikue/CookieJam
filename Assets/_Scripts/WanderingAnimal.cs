using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAnimal : MonoBehaviour
{
    public float range;
    public float speed;
    public float waitTime;

    private Vector2 homePos;
    private Rigidbody2D rb;
    private Vector2 goalPos;
    private bool waiting = false;

    private void Start()
    {
        homePos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (waiting) return;

        if (Vector2.Distance(rb.position, goalPos) < 0.1f)
        {
            StartCoroutine(WaitAndPickNewSpot());
            return;
        }

        Vector2 diff = goalPos - rb.position;
        Vector2 step = diff.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + step);
    }

    private IEnumerator WaitAndPickNewSpot()
    {
        rb.velocity = Vector2.zero;
        waiting = true;
        yield return new WaitForSeconds(waitTime);
        float angle = Random.Range(0, 2 * Mathf.PI);
        float r = Random.Range(0, range);
        goalPos = homePos + new Vector2(r * Mathf.Cos(angle), r * Mathf.Sin(angle));
        waiting = false;
    }
}
