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
    private int score;
    private string name;

    void Start() {
        scoresCtrl = gameObject.GetComponent<ScoresController>();
        Debug.Assert(scoresCtrl != null, "Scores Controller must be assigned.");
        name = "";
        score = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            print("E key was pressed");
            topScores.text = scoresCtrl.GetUserScores().ToString();
        }
        if (Input.GetKeyDown(KeyCode.Return) && nameInputField.text != "") {
            print("Enter was pressed");
            var userScore = new UserScore(nameInputField.text, score);
            scoresCtrl.CreateOrUpdateUserScore(userScore);
        }
    }

    public void UpdateCurrentScore() {
        score++;
        SetCountText();
    }

    void SetCountText() {
        if (currentScoreText == null)
            return;
        currentScoreText.text = "Score: " + score.ToString();
    }
}