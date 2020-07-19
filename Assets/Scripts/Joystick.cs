using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour {
    public static Joystick Instance { get; private set; }
    public Transform player;
    public Transform clonePlayer;
    public float speed = 2.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    public Transform circle;
    public Transform outerCircle;
    public bool blockPlayer;
    public bool blockClonePlayer;

    private void Awake () {
        if (Instance == null)
            Instance = this;
        else
            Destroy (gameObject);
    }
    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            pointA = Camera.main.ScreenToWorldPoint (new Vector3 (
                Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.transform.position.z
            ));
        }

        if (Input.GetMouseButton (0)) {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint (new Vector3 (
                Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.transform.position.z
            ));

        } else {
            touchStart = false;
        }
    }

    private void FixedUpdate () {
        if (touchStart) {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude (offset, 1.0f);
            Move (direction);

            circle.transform.position = new Vector2 (
                pointA.x + direction.x,
                pointA.y + direction.y);

            outerCircle.transform.position = new Vector2 (
                pointA.x + direction.x,
                pointA.y + direction.y);
        }
    }
    void Move (Vector2 direction) {

        Player Player = player.GetComponent<Player> ();
        Player.FlipX (Input.mousePosition.x > 0 ? false : true);
        blockPlayer = Player.block;

        if (!blockPlayer)
            player.Translate (direction * speed * Time.deltaTime);

        Player ClonePlayer = clonePlayer.GetComponent<Player> ();
        ClonePlayer.FlipX (Input.mousePosition.x > 0 ? false : true);
        blockClonePlayer = ClonePlayer.block;

        if (!blockClonePlayer)
            clonePlayer.Translate (direction * speed * Time.deltaTime);
    }
}