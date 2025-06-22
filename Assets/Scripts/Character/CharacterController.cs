using UnityEngine;
using Scripts.MoveSystem;
using Scripts.InputSystem;
using Scripts.HealthSystem;

public sealed class CharacterController : MonoBehaviour, IHealthProvider
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D playerRb;
    public Rigidbody2D PlayerRb => playerRb;

    private IHealth _healthSystem;
    private IMove _moveSystem;
    private IInput _inputSystem;

    public IHealth Health => _healthSystem;

    private bool characterIsReady = false;

    public void Init(IHealth health, IMove move, IInput input)
    {
        if (player == null)
        {
            Debug.LogError("[CHARCTER_CONTROLLER] Player is null");
            return;
        }

        if (playerRb == null)
        {
            Debug.LogError("[CHARCTER_CONTROLLER] Rb is null");
            return;
        }

        _healthSystem = health;
        _moveSystem = move;
        _inputSystem = input;

        if (_healthSystem == null)
        {
            Debug.LogError("[CHARCTER_CONTROLLER] HealthSystem is null");
            return;
        }

        if (_moveSystem == null)
        {
            Debug.LogError("[CHARCTER_CONTROLLER] MoveSystem is null");
            return;
        }

        if (_inputSystem == null)
        {
            Debug.LogError("[CHARCTER_CONTROLLER] InputSystem is null");
            return;
        }

        if (_inputSystem == null)
        {
            Debug.LogError("[CHARCTER_CONTROLLER] InputSystem is null");
            return;
        }

        _healthSystem.hpEmpty += Death;

        Debug.Log("[CHARCTER_CONTROLLER] Player is ready");
        characterIsReady = true;
    }


    private void FixedUpdate()
    {
        if (!characterIsReady)
        {
            Debug.LogError("[CHARCTER_CONTROLLER] Player is not init");
            return;
        }

        PlayerMove();

        if (_inputSystem.IsFirePressed())
        {
            PlayerAttack();
        }
    }

    public void PlayerMove()
    {
        Vector2 direction = new(_inputSystem.GetHorizontal(), 0);
        _moveSystem.MoveByRigidbodyVelocity(direction * Time.deltaTime);
    }

    private void PlayerAttack()
    {
        
    }

    private void OnDisable()
    {
        _healthSystem.hpEmpty -= Death;
    }

    private void Death() => Destroy(player);
}