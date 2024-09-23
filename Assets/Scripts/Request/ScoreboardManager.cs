using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ScoreData
{
    public string player;
    public string game;
    public int score;
    public string date;
}

[System.Serializable]
public class ScoreWrapper
{
    public List<ScoreData> scores;
}

public class ScoreboardManager : Singleton<ScoreboardManager>
{
    private const string API_URL = "http://127.0.0.1:5000/api";

    public void GetScores(System.Action<List<ScoreData>> callback)
    {
        StartCoroutine(GetScoresCoroutine(callback));
    }

    private IEnumerator GetScoresCoroutine(System.Action<List<ScoreData>> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"{API_URL}/scores"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Error: {www.error}");
                callback(null);
            }
            else
            {
                string json = www.downloadHandler.text;
                ScoreWrapper scoreWrapper = JsonUtility.FromJson<ScoreWrapper>($"{{\"scores\":{json}}}");
                List<ScoreData> scores = scoreWrapper.scores;
                callback(scores);
            }
        }
    }

    public void SubmitScore(string playerName, string gameName, int score, System.Action<bool> callback)
    {
        StartCoroutine(SubmitScoreCoroutine(playerName, gameName, score, callback));
    }

    private IEnumerator SubmitScoreCoroutine(string playerName, string gameName, int score, System.Action<bool> callback)
    {
        ScoreData newScore = new ScoreData
        {
            player = playerName,
            game = gameName,
            score = score
        };

        string json = JsonUtility.ToJson(newScore);

        using (UnityWebRequest www = UnityWebRequest.PostWwwForm($"{API_URL}/submit_score", json))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Error: {www.error}");
                callback(false);
            }
            else
            {
                callback(true);
            }
        }
    }
}