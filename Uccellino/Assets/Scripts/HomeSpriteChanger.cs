using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSpriteChanger : MonoBehaviour
{
    public PlayerController characterControl;
    public Sprite[] homeSprites;
    internal int currentHomeSprite;
    internal SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        currentHomeSprite = 0;
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = homeSprites[0]; // set the sprite to sprite0

    }

    // Update is called once per frame
    void Update()
    {
    }
}
