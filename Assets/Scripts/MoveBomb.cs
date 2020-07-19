using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBomb : MonoBehaviour {

    public Vector2 direction;
    public float speed;
    private void FixedUpdate () {
        Move ();
        CheckExitScene ();
    }
    void Move () {
        gameObject.transform.Translate (direction * speed * Time.deltaTime);
    }

    void CheckExitScene () {
        GameObject target = GameObject.FindGameObjectWithTag ("BarriersRight");
        if (gameObject.transform.position.x > target.transform.position.x) {
            Destroy (gameObject, 2f);
        }
    }
}