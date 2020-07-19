using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public static Spawn Instance { get; private set; }
    public GameObject bomb;
    private MoveBomb moveBomb;
    public float timerInterval = 1.3f;

    private void Awake () {
        if (Instance == null)
            Instance = this;
        else
            Destroy (gameObject);
    }
    void Start () {
        moveBomb = bomb.GetComponent<MoveBomb> ();
        SetSpeedBomb (1.2f);
        StartSpawn ();
    }

    void SpawnBomb () {
        Vector3 pos = new Vector3 (-10, Random.Range (-2f, 4f), 0);
        Instantiate (bomb, pos, Quaternion.identity, gameObject.transform);
    }
    public void SetSpeedBombIncrement (float value) {
        moveBomb.speed = moveBomb.speed + value;
    }
    public void SetSpeedBomb (float value) {
        moveBomb.speed = value;
    }

    public void StartSpawn (float value = 0) {
        CancelInvoke ();
        InvokeRepeating ("SpawnBomb", 0f, timerInterval - value);
    }
}