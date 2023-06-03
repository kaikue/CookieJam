using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FoodItem : MonoBehaviour
{
    FoodScriptable foodScriptable;
    SpriteRenderer spriteRenderer;
    [SerializeField] private GameEvent PlayerEat;

    public void CreateFood(FoodScriptable scriptable)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        foodScriptable = scriptable;
        spriteRenderer.sprite = foodScriptable.sprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            PlayerEat?.TriggerEvent(this, foodScriptable);
            Destroy(gameObject);
        }
    }
}
