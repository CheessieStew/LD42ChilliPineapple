using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace FlappyDrake.API {
  [Serializable]
  public class Scores {
    public override string ToString() {
      var scoresString = "";
      foreach (UserScore score in scores) {
        scoresString += score.ToString() + "\n";
      }
      return scoresString;
    }
    public List<UserScore> scores;
  }
}