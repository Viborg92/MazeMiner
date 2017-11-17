using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// BaseButtonEffects.
/// Implements Pointer-Enter,Exit and down
/// Inorder to inherit to all over potential button wihtin the game.
/// </summary>
public abstract class BaseButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField]
    ParticleSystem particlesystem;

    protected virtual void Awake()
    {
        particlesystem.Stop();
    }

    public abstract void OnPointerDown(PointerEventData dataname);

    public void OnPointerEnter(PointerEventData dataname)
    {
        particlesystem.Play();
    }

    public void OnPointerExit(PointerEventData dataname)
    {
        particlesystem.Stop();
    }
}
