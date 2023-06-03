using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Evolution Thresholds")]
    [SerializeField] public int coldThreshold;
    [SerializeField] public int digThreshold;
    [SerializeField] public int swimThreshold;
    [SerializeField] public int flyThreshold;
    [SerializeField] public int playerSpeedThreshold;
    

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
            Debug.Log("Player Ate");
            stats.cold += food.cold;
            stats.dig += food.dig;
            stats.swim += food.swim;
            stats.fly += food.fly;
            stats.playerSpeed += food.playerSpeed;
            UpdateStats?.TriggerEvent(this, stats);
        }

        if (stats.swim > swimThreshold)
        {
            PlayerManager.Instance.Evolve(PlayerManager.EvolutionState.SWIM);
        }
        if (stats.dig > digThreshold)
        {
            PlayerManager.Instance.Evolve(PlayerManager.EvolutionState.DIG);
        }
        if (stats.fly > flyThreshold)
        {
            PlayerManager.Instance.Evolve(PlayerManager.EvolutionState.FLY);
        }

    }
}
