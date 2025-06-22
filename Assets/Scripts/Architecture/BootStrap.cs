using UnityEngine;
using Scripts.MoveSystem;
using Scripts.InputSystem;
using Scripts.HealthSystem;
using Scripts.BulletSystem;
using Scripts.BulletsSystem;

namespace Scripts.Architecture
{
    public sealed class BootStrap : MonoBehaviour
    {
        #region Player

        [Header("=======Player=======")]

        [SerializeField] private CharacterController characterController;

        [Header("PlayerInput")]
        [SerializeField] private KeyCode leftMoveBtn;
        [SerializeField] private KeyCode rightMoveBtn;
        [SerializeField] private KeyCode fireBtn;

        private IInput playerInputSystem;


        [Header("PlayerHealth")]
        [SerializeField, Range(1, 50)] private int playerHealth;
        private IHealth playerHealthSystem;

        [Header("PlayerMove")]
        [SerializeField, Range(1, 10)] private float playerSpeed;
        private IMove playerMoveSystem;

        [Header("PlayerBullets")]
        [SerializeField] private Transform playerBulletStartPos;
        [SerializeField] private BulletCfg playerBulletCfg;
        private IBullet playerBullet;

        #endregion

        [Space]

        #region Enemies

        [Header("=======Enemy=======")]
        [SerializeField] private Transform enemy;
        //[Space]

        [Header("EnemyHealth")]
        [SerializeField, Range(1, 50)] private int enemyHealth;
        [SerializeField] private IHealth enemyHealthSystem;
        
        //[Space]

        [Header("EnemyMove")]
        [SerializeField, Range(1, 10)] private float enemySpeed;

        [Header("EnemyBullet")]
        [SerializeField] private BulletCfg enemyBulletCfg;
        [SerializeField] private GameObject enemyBulletPrefab;
        [SerializeField] private Transform bulletContainer;

        #endregion

        private void Awake()
        {
            PlayerPreparation();
        }

        private void PlayerPreparation()
        {
            if (characterController == null)
            {
                Debug.LogError("[BOOTSTRAP] CharacterController is null");
                return;
            }

            playerHealthSystem = new Health(playerHealth);
            playerMoveSystem = new Move(characterController.PlayerRb, playerSpeed);
            playerInputSystem = new KeyboardInput(leftMoveBtn, rightMoveBtn, fireBtn);

            characterController.Init(playerHealthSystem, playerMoveSystem, playerInputSystem);
        }

        private void EnemyPreparation()
        {
            //enemyHealthSystem = new Health(enemyHealth);
        }
    }
}