using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Food")]
public class FoodScriptable : ScriptableObject
{
    public Sprite sprite;

    [Header("Food Stat")]
    //used to survive ice age
    public int cold;
    //used to survive meteor
    public int dig;
    //used to survive flood
    public int swim;
    //used to be able to move around faster
    public int fly;

    [Header("Use if wandering food")]
    public bool isWandering;
    public float range;
    public float speed;
    public float waitTime;
}
