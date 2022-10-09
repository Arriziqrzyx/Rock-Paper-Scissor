using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Attack AttackValue;
    public Player player;
    public Vector2 originalPosition;
    Vector2 originalScale;
    Color originalColor;
    bool isClickable=true;

    private void Start()
    {
        originalPosition = this.transform.position;
        originalScale = this.transform.localScale;
        originalColor = GetComponent<Image>().color;
    }

    public void Onclick()
    {
        if (isClickable)
        player.SetChosenCard(this);
    }

    internal void Reset()
    {
        transform.position = originalPosition;
        transform.localScale = originalScale;
        GetComponent<Image>().color = originalColor;
    }

    public void setClickable (bool value)
    {
        isClickable = value;
    }
}
