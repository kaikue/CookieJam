using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{

    [SerializeField] private GameObject _flyingModule;
    [SerializeField] private GameObject _swimmingModule;


    public enum EvolutionState
    {
        SWIM,
        FLY
    }

    private void Start()
    {
        _flyingModule.SetActive(false);
        _swimmingModule.SetActive(false);
    }

    // TEST Func replace with above
    public void Evolve(EvolutionState state)
    {
        switch (state)
        {
            case EvolutionState.SWIM:
                _swimmingModule.SetActive(true);
                break;
            case EvolutionState.FLY:
                _flyingModule.SetActive(true);
                break;
            default:
                break;
        }
    }

}
