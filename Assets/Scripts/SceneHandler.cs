using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public SelectionsManager _selectionsManager;

    //[SerializeField] GameEventNoParam _onNextLevelEvent;
    //[SerializeField] GameEventNoParam _onOnReturnToLevel1Event;

    public void openAnd()
    {
        _selectionsManager.OnOpenICAND();
    }

    public void openOR()
    {
        _selectionsManager.OnOpenICOR();
    }

    public void openNAND()
    {
        _selectionsManager.OnOpenICNAND();
    }

    public void openNOR()
    {
        _selectionsManager.OnOpenICNOR();
    }

    public void openNOT()
    {
        _selectionsManager.OnOpenICNOT();
    }

    public void openXOR()
    {
        _selectionsManager.OnOpenICXOR();
    }

    public void openXNOR()
    {
        _selectionsManager.OnOpenICXNOR();
    }

    public void OnNextLevel(int sceneIndex)
    {
        //_onNextLevelEvent.Raise();
        SceneManager.LoadScene(sceneIndex);
    }

    public void OnRestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnPlayScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void OnMainMenuScene()
    {
        Time.timeScale = 1;
        //if(BGM.instance != null) BGM.instance.DestroyBGMGameObject();
        //_playerData.ResetData();
        SceneManager.LoadScene(2);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
