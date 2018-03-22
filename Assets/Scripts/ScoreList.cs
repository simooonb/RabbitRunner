using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ScoreList : MonoBehaviour
{
    static List<float> scoreList;

    static ScoreList()
    {
        scoreList = new List<float>(PlayerPrefsX.GetFloatArray("scores"));
    }

    public static void add(float score)
    {	
        scoreList.Add(score);
        scoreList = scoreList.OrderByDescending(s => s).ToList();

        registerScores();
    }

    public static List<float> getList()
    {
        return scoreList;
    }

    static void registerScores()
    {
        PlayerPrefsX.SetFloatArray("scores", scoreList.ToArray());
    }
}

