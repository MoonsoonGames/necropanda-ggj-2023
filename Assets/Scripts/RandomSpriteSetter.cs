using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteSetter : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
