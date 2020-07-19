using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public static Game Instance { get; private set; }
    public Text scoreText;
    public int score;
    private void Awake () {
        if (Instance == null)
            Instance = this;
        else
            Destroy (gameObject);
    }
    void Update () {
        SetScore ();
    }

    public void SetScore () {
        if (Joystick.Instance.blockPlayer && Joystick.Instance.blockClonePlayer) {
            score++;
            scoreText.text = score.ToString ();

            Player Player = Joystick.Instance.player.GetComponent<Player> ();
            Player.ResetPosition ();

            Player ClonePlayer = Joystick.Instance.clonePlayer.GetComponent<Player> ();
            ClonePlayer.ResetPosition ();

            Spawn.Instance.SetSpeedBombIncrement (0.2f);
            Spawn.Instance.StartSpawn(0.2f);
        }
    }
}