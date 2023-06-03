using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{

    [SerializeField] private GameObject _flyingModule;
    [SerializeField] private GameObject _swimmingModule;
    [SerializeField] private GameObject _diggingModule;

    [SerializeField] private Rigidbody2D _playerBody;

    public bool CanSwim = false;
    public bool CanFly = false;
    public bool CanDig = false;

    public PlayerStats stats;

    public enum EvolutionState
    {
        DIG,
        FLY,
        SWIM,
    }

    private void Start()
    {
        refreshVisuals();
        _playerBody.gameObject.GetComponent<PlayerStats>();
    }

    public void Evolve(EvolutionState state)
    {
        switch (state)
        {
            case EvolutionState.SWIM:
                Physics2D.IgnoreLayerCollision(3, 4, true);
                CanSwim = true;
                break;
            case EvolutionState.FLY:
                Physics2D.IgnoreLayerCollision(3, 4, true);
                Physics2D.IgnoreLayerCollision(3, 6, true);
                CanFly = true;
                break;
            case EvolutionState.DIG:
                Physics2D.IgnoreLayerCollision(3, 6, true);
                CanDig = true;
                break;
            default:
                break;
        }

        refreshVisuals();
    }

    private void refreshVisuals()
    {
        _flyingModule.SetActive(CanFly);
        _swimmingModule.SetActive(CanSwim);
        _diggingModule.SetActive(CanDig);
    }

}
