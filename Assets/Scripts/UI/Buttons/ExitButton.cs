using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : BaseButtonEffects
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData dataname)
    {
        Application.Quit();
    }
}
