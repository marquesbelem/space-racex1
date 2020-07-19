using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool block;
    private SpriteRenderer sprite;
    private Animator animator;
    private void Start () {
        sprite = GetComponent<SpriteRenderer> ();
        animator = GetComponent<Animator> ();
    }
    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.CompareTag ("Bomb"))
            ResetPosition ();
        if (col.gameObject.CompareTag ("BarriersUp"))
            block = true;
    }

    public void FlipX (bool status) {
        sprite.flipX = status;
    }

    public void SetAnimation (string name) {
        animator.SetTrigger (name);
    }
    public void ResetAnimation (string name) {
        animator.ResetTrigger (name);
    }

    public void ResetPosition () {
        gameObject.transform.position = new Vector3 (gameObject.transform.position.x, -3.5f, 0);
        block = false;
    }
}