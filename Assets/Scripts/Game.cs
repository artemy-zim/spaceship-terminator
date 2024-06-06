using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private PlayerShip _player;
    [SerializeField] private PlayerShotSpawner _playerShotSpawner;
    [SerializeField] private EnemyShotSpawner _enemyShotSpawner;
    [SerializeField] private EnemyShipSpawner _enemyShipSpawner;
    [SerializeField] private InputHandler _input;

    private void Awake()
    {
        Time.timeScale = 0f;
        _startScreen.Open();

        _input.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClicked;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClicked;
    }

    private void OnGameOver()
    {
        Time.timeScale = 0f;
        _endGameScreen.Open();

        _input.gameObject.SetActive(false);
    }

    private void OnPlayButtonClicked()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClicked()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        _player.Reset();
        _enemyShotSpawner.Reset();
        _enemyShipSpawner.Reset();
        _playerShotSpawner.Reset();

        _input.gameObject.SetActive(true);
    }
}
