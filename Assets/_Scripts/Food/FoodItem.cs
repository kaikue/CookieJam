using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FoodItem : MonoBehaviour
{
    FoodScriptable foodScriptable;
    SpriteRenderer spriteRenderer;

    public void CreateFood(FoodScriptable scriptable)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        foodScriptable = scriptable;
        spriteRenderer.sprite = foodScriptable.sprite;
    }
}
