using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    //[SerializeField] GameEventNoParam _onNextLevelEvent;
    //[SerializeField] GameEventNoParam _onOnReturnToLevel1Event;
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
