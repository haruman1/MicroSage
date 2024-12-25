using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionsManager : MonoBehaviour
{
    [Header("Pilih Menu")]
    public GameObject _stageSelections;
    public GameObject _quizselections;
    public GameObject _simulasiSelections;

    [Header("Pilih Leaderboard")]
    public GameObject _leaderboardQuiz;
    public GameObject _leaderboardSimulasi;

    [Header("Loading Screen")]
    public GameObject _loadingScreen;

    // Start is called before the first frame update
    void Start()
    {
        OnOpenStageSelection();
    }

    public void OnOpenLeaderboardQuiz()
    {
        _leaderboardQuiz.SetActive(true);
        _quizselections.SetActive(true);
        _leaderboardSimulasi.SetActive(false);
        _loadingScreen.SetActive(false);
        _stageSelections.SetActive(false);
        _simulasiSelections.SetActive(false);
    }

    public void OnOpenLeaderboardSimulasi()
    {
        _leaderboardSimulasi.SetActive(true);
        _simulasiSelections.SetActive(true);
        _leaderboardQuiz.SetActive(false);
        _loadingScreen.SetActive(false);
        _quizselections.SetActive(false);
        _stageSelections.SetActive(false);
    }

    public void ResetScoreSimulasi()
    {
        string[] categories = { "AND", "OR", "NAND", "NOR", "NOT", "XOR", "XNOR" };
        foreach (string name in categories)
        {
            PlayerPrefs.SetInt("Score_Simulations_" + name, 0);
        }
    }

    public void ResetScoreQuiz()
    {
        string[] categories = { "AND", "OR", "NAND", "NOR", "NOT", "XOR", "XNOR" };
        foreach (string name in categories)
        {
            PlayerPrefs.SetInt("Score_Quiz_" + name, 0);
        }
    }

    // Update is called once per frame
    public void OnOpenLoadingScreen()
    {
        _loadingScreen.SetActive(true);
        _stageSelections.SetActive(false);
        _quizselections.SetActive(false);
        _simulasiSelections.SetActive(false);
        _leaderboardSimulasi.SetActive(false);
        _leaderboardQuiz.SetActive(false);
    }

    public void onOpenSimulasiSelection()
    {
        _simulasiSelections.SetActive(true);
        _quizselections.SetActive(false);
        _loadingScreen.SetActive(false);
        _stageSelections.SetActive(false);
        _leaderboardSimulasi.SetActive(false);
        _leaderboardQuiz.SetActive(false);
    }

    public void onOpenQuizSelection()
    {
        _quizselections.SetActive(true);
        _simulasiSelections.SetActive(false);
        _stageSelections.SetActive(false);
        _loadingScreen.SetActive(false);
        _leaderboardSimulasi.SetActive(false);
        _leaderboardQuiz.SetActive(false);
    }

    public void OnOpenStageSelection()
    {
        _stageSelections.SetActive(true);
        _quizselections.SetActive(false);
        _loadingScreen.SetActive(false);
        _simulasiSelections.SetActive(false);
    }
}
