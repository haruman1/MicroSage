using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("Simulasi Management")]
    public TextMeshProUGUI _headerSimulasi;
    public GameObject[] _stageSelectionUI;
    public GameObject _simulasiContainer;

    [Header("Quiz Management")]
    public int quizIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        OnOpenStageSelection();
    }

    //Simulasi Management

    public void OnOpenICAND()
    {
        _headerSimulasi.text = "IC AND";
        for (int i = 0; i < _stageSelectionUI.Length; i++)
        {
            _stageSelectionUI[i].SetActive(false);
        }
        _simulasiContainer.SetActive(true);
        _stageSelectionUI[0].SetActive(true);
        _leaderboardSimulasi.SetActive(false);
        _loadingScreen.SetActive(false);
        _stageSelections.SetActive(false);
        _simulasiSelections.SetActive(false);
        _stageSelections.SetActive(false);
    }

    public void OnOpenICOR()
    {
        _headerSimulasi.text = "IC OR";
        for (int i = 0; i < _stageSelectionUI.Length; i++)
        {
            _stageSelectionUI[i].SetActive(false);
        }
        _simulasiContainer.SetActive(true);
        _stageSelectionUI[1].SetActive(true);
        _leaderboardSimulasi.SetActive(false);
        _loadingScreen.SetActive(false);
        _stageSelections.SetActive(false);
        _simulasiSelections.SetActive(false);
        _stageSelections.SetActive(false);
    }

    public void OnOpenICNAND()
    {
        _headerSimulasi.text = "IC NAND";
        for (int i = 0; i < _stageSelectionUI.Length; i++)
        {
            _stageSelectionUI[i].SetActive(false);
        }
        _simulasiContainer.SetActive(true);
        _stageSelectionUI[2].SetActive(true);
        _leaderboardSimulasi.SetActive(false);
        _loadingScreen.SetActive(false);
        _stageSelections.SetActive(false);
        _simulasiSelections.SetActive(false);
        _stageSelections.SetActive(false);
    }

    public void OnOpenICXOR()
    {
        _headerSimulasi.text = "IC XOR";
        for (int i = 0; i < _stageSelectionUI.Length; i++)
        {
            _stageSelectionUI[i].SetActive(false);
        }
        _simulasiContainer.SetActive(true);
        _stageSelectionUI[3].SetActive(true);
        _leaderboardSimulasi.SetActive(false);
        _loadingScreen.SetActive(false);
        _stageSelections.SetActive(false);
        _simulasiSelections.SetActive(false);
        _stageSelections.SetActive(false);
    }

    public void OnOpenICNOR()
    {
        _headerSimulasi.text = "IC NOR";
        for (int i = 0; i < _stageSelectionUI.Length; i++)
        {
            _stageSelectionUI[i].SetActive(false);
        }
        _simulasiContainer.SetActive(true);
        _stageSelectionUI[4].SetActive(true);
        _leaderboardSimulasi.SetActive(false);
        _loadingScreen.SetActive(false);
        _stageSelections.SetActive(false);
        _simulasiSelections.SetActive(false);
        _stageSelections.SetActive(false);
    }

    public void OnOpenICXNOR()
    {
        _headerSimulasi.text = "IC XNOR";
        for (int i = 0; i < _stageSelectionUI.Length; i++)
        {
            _stageSelectionUI[i].SetActive(false);
        }
        _simulasiContainer.SetActive(true);
        _stageSelectionUI[5].SetActive(true);
        _leaderboardSimulasi.SetActive(false);
        _loadingScreen.SetActive(false);
        _stageSelections.SetActive(false);
        _simulasiSelections.SetActive(false);
        _stageSelections.SetActive(false);
    }

    public void OnOpenICNOT()
    {
        _headerSimulasi.text = "IC NOT";
        for (int i = 0; i < _stageSelectionUI.Length; i++)
        {
            _stageSelectionUI[i].SetActive(false);
        }
        _simulasiContainer.SetActive(true);
        _stageSelectionUI[6].SetActive(true);
        _leaderboardSimulasi.SetActive(false);
        _loadingScreen.SetActive(false);
        _stageSelections.SetActive(false);
        _simulasiSelections.SetActive(false);
        _stageSelections.SetActive(false);
    }

    //


    public void OnOpenLeaderboardQuiz()
    {
        _leaderboardQuiz.SetActive(true);
        _quizselections.SetActive(true);
        _leaderboardSimulasi.SetActive(false);
        _loadingScreen.SetActive(false);
        _stageSelections.SetActive(false);
        _simulasiSelections.SetActive(false);
        _simulasiContainer.SetActive(false);
    }

    public void OnOpenLeaderboardSimulasi()
    {
        _leaderboardSimulasi.SetActive(true);
        _simulasiSelections.SetActive(true);
        _leaderboardQuiz.SetActive(false);
        _loadingScreen.SetActive(false);
        _quizselections.SetActive(false);
        _stageSelections.SetActive(false);
        _simulasiContainer.SetActive(false);
    }

    public void ResetScoreSimulasi()
    {
        string[] categories = { "AND", "OR", "NAND", "NOR", "NOT", "XOR", "XNOR" };
        // KALAU MAU DI KATEGORIKAN
        // string[] stage = { "TTL", "CMOS", "HCMOS" };
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
        _simulasiContainer.SetActive(false);
    }

    public void onOpenSimulasiSelection()
    {
        _simulasiSelections.SetActive(true);
        _quizselections.SetActive(false);
        _loadingScreen.SetActive(false);
        _stageSelections.SetActive(false);
        _leaderboardSimulasi.SetActive(false);
        _leaderboardQuiz.SetActive(false);
        _simulasiContainer.SetActive(false);
    }

    public void onOpenQuizSelection()
    {
        _quizselections.SetActive(true);
        _simulasiSelections.SetActive(false);
        _stageSelections.SetActive(false);
        _loadingScreen.SetActive(false);
        _leaderboardSimulasi.SetActive(false);
        _leaderboardQuiz.SetActive(false);
        _simulasiContainer.SetActive(false);
    }

    public void OnOpenStageSelection()
    {
        _stageSelections.SetActive(true);
        _quizselections.SetActive(false);
        _loadingScreen.SetActive(false);
        _simulasiSelections.SetActive(false);
        _simulasiContainer.SetActive(false);
    }

    //Simulasi Management


    //QUIZ MANAGEMENT

    public void OnQuizSelected(int quizIndex)
    {
        PlayerPrefs.SetInt("SelectedCategory", quizIndex);
    }
}
