using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// New game button.
/// Is assigend to a Buttons onClick function
/// It will then reset the playerprefs and load the gamescene.
/// </summary>
public class NewGameButton : BaseButtonEffects
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData dataname)
    {
        PlayerPrefs.SetInt("Floor", 0);
        SceneManager.LoadScene("TesteScene 1.0");
    }
}
