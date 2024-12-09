using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XnorStage : MonoBehaviour
{
    [SerializeField]
    private List<Button> _XnorStage;
    private int _unlockedLevel = 1;

    private void Start()
    {
        for (int i = 0; i < _XnorStage.Count; i++)
        {
            if (i != 0)
                _XnorStage[i].interactable = false;
        }

        if (PlayerPrefs.HasKey("XnorStage"))
        {
            _unlockedLevel = PlayerPrefs.GetInt("XnorStage", 1);
        }
        else
            PlayerPrefs.SetInt("XnorStage", 1);

        for (int i = 0; i < _unlockedLevel; i++)
        {
            _XnorStage[i].interactable = true;
        }
    }
}
