using System.Collections;
using System.Collections.Generic;
using API;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour {

    public Text topScores;
    public Text currentScoreText;
    public InputField nameInputField;

    private ScoresController scoresCtrl;
    private int _score;
    public int Score {
        get { return _score; }
        set {
            _score = value;
            SetCountText();
        }
    }
    private bool showTopScores;

    void Start() {
        scoresCtrl = gameObject.GetComponent<ScoresController>();
        Debug.Assert(scoresCtrl != null, "Scores Controller must be assigned.");
        Score = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            print("E key was pressed");
            if (showTopScores) HideTopScores();
            else ShowTopScores();
        }
    }

    public void ShowTopScores() {
        try {
            var scores = scoresCtrl.GetUserScores().ToString();
            topScores.text = scoresCtrl.GetUserScores().ToString();
        } catch (System.Exception ex) {
            Debug.Log(ex);
        }
    }

    public void HideTopScores() {
        topScores.text = "";
    }

    public void SendUserScore() {
        var userScore = new UserScore(nameInputField.text, Score);
        scoresCtrl.CreateOrUpdateUserScore(userScore);
    }

    void SetCountText() {
        if (currentScoreText == null)
            return;
        currentScoreText.text = $"Score: {Score}";
    }
}