using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace API {
    [Serializable]
    public class UserScore {
        public UserScore(string name, int score) {
            player = name;
            value = score;
            created_at = (int) Time.time;
        }

        public string ToJSONString() {
            return "{\"player\": \"" + player + "\", \"value\": " + value + ", \"created_at\": " + created_at + "}";
        }

        public string ToString() {
            return player + ": " + value;
        }

        public string player;
        public int value;
        public int created_at;
    }

    [Serializable]
    public class Scores {
        public string ToString() {
            var scoresString = "";
            foreach (UserScore score in scores) {
                scoresString += score.ToString() + "\n";
            }
            return scoresString;
        }
        public List<UserScore> scores;
    }
}