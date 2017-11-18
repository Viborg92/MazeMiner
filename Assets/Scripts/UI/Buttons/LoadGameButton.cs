using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Load game button.
/// Takes the saved floor data, and uses it to assign the floor playerpref.
/// </summary>
public class LoadGameButton : BaseButtonEffects
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData dataname)
    {
        int LoadedFloor;
        LoadedFloor = PlayerPrefs.GetInt("SavedFloor", 0);
        PlayerPrefs.SetInt("Floor", LoadedFloor);
    }
}
