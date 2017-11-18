using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Continue button.
/// Makes the next floor.
/// </summary>
public class ContinueButton : BaseButtonEffects
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData dataname)
    {
        SceneManager.LoadScene("GameScene");
    }
}
