using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace API {
  public class ScoresController : MonoBehaviour {
    public void CreateOrUpdateUserScore(UserScore score) {
      StartCoroutine(HandleCreateOrUpdate(score));
    }

    public Scores GetUserScores() {
      HttpWebRequest request = (HttpWebRequest) WebRequest.Create("https://snake-api.glitch.me/v1/scores");
      HttpWebResponse response = (HttpWebResponse) request.GetResponse();
      StreamReader reader = new StreamReader(response.GetResponseStream());
      string jsonResponse = reader.ReadToEnd();
      Scores scores = JsonUtility.FromJson<Scores>("{\"scores\": " + jsonResponse + "}");
      Debug.Log(jsonResponse);
      return scores;
    }

    IEnumerator HandleCreateOrUpdate(UserScore score) {
      UnityWebRequest www = UnityWebRequest.Put("https://snake-api.glitch.me/v1/scores", score.ToJSONString());
      www.SetRequestHeader("Content-Type", "application/json");
      www.chunkedTransfer = false;
      www.method = "POST";
      yield return www.Send();

      if (www.isNetworkError || www.isHttpError) {
        Debug.Log(www.error);
      } else {
        Debug.Log("Done!");
      }
    }
  }
}