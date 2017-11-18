using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main menu button.
/// Takes the player to the MainMenu scene.
/// </summary>
public class MainMenuButton : BaseButtonEffects
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData dataname)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
