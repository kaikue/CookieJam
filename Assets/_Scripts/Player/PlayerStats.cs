using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Evolution Thresholds")]
    [SerializeField] private int coldThreshold;
    [SerializeField] private int digThreshold;
    [SerializeField] private int swimThreshold;
    [SerializeField] private int flyThreshold;
    [SerializeField] private int playerSpeedThreshold;
    

    public struct PStats
    {
        //used to survive ice age
        public int cold;
        //used to survive meteor
        public int dig;
        //used to survive flood
        public int swim;
        //used to be able to move around faster
        public int fly;
        public int playerSpeed;

        public PStats(int cold, int dig, int swim, int fly, int playerSpeed)
        {
            this.cold = cold;
            this.dig = dig;
            this.swim = swim;
            this.fly = fly;
            this.playerSpeed = playerSpeed;
        }
    }
    public PStats stats;

    [Header("Events")]
    [SerializeField] private GameEvent UpdateStats;

    private void Awake()
    {
        stats = new PStats(0, 0, 0, 0, 0);
    }

    public void EatFood(Component sender, object data)
    {
        if (data is FoodScriptable food)
        {
            stats.cold += food.cold;
            stats.dig += food.dig;
            stats.swim += food.swim;
            stats.fly += food.fly;
            stats.playerSpeed += food.playerSpeed;
            UpdateStats?.TriggerEvent(this, stats);
        }
        
    }
}
