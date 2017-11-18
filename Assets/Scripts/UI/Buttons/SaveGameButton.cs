using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Save game button.
/// Takes saves the current floor count
/// making it so that the player is able to load it from the main menu.
/// </summary>
public class SaveGameButton : BaseButtonEffects
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData dataname)
    {
        int savingData;
        savingData = PlayerPrefs.GetInt("Floor", 0);
        PlayerPrefs.SetInt("SavedFloor", savingData);
    }
}
