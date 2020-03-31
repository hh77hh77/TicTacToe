using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldElement : MonoBehaviour
{
    public int id;
    public ColyseusClient colyseusClient;
    public Sprite sprite;
    public Sprite playerSprite;
    public Sprite enemySprite;

    void Start()
    {
        colyseusClient.changeField.AddListener(OnFieldChange);
    }
    private void OnMouseDown()
    {
        colyseusClient.SendMessage(id);
    }

    private void OnFieldChange(string owner, int field)
    {
        if (field == id)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (owner == colyseusClient.playerId)
            {
                spriteRenderer.sprite = playerSprite;
            }
            else if (owner == "")
            {
                spriteRenderer.sprite = sprite;
            }
            else
            {
                spriteRenderer.sprite = enemySprite;
            }
        }
    }
}