using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace API
{
    [Serializable]
    public class UserScore
    {
        public UserScore(string name, int score)
        {
            player = name;
            value = score;
            created_at = (int)Time.time;
        }

        public string ToString()
        {
            return "{\"player\": \"" + player + "\", \"value\": " + value + ", \"created_at\": " + created_at + "}";
        }

        public string player { get; set; }
        public int value { get; set; }
        public int created_at { get; set; }
    }

    [Serializable]
    public class Scores
    {
        public List<UserScore> scores;
    }

    public class ScoresController : MonoBehaviour
    {
        public void CreateOrUpdateUserScore(UserScore score)
        {
            StartCoroutine(HandleCreateOrUpdate(score));
        }

        public Scores GetUserScores()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://snake-api.glitch.me/v1/scores");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            Scores scores = JsonUtility.FromJson<Scores>("{\"scores\": " + jsonResponse + "}");
            return scores;
        }

        IEnumerator HandleCreateOrUpdate(UserScore score)
        {
            var json_data = score.ToString();
            UnityWebRequest www = UnityWebRequest.Put("https://snake-api.glitch.me/v1/scores", score.ToString());
            www.SetRequestHeader("Content-Type", "application/json");
            www.chunkedTransfer = false;
            www.method = "POST";
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Done!");
            }
        }
    }
}
