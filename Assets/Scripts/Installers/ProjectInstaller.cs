using UnityEngine;

public class ProjectInstaller : MonoBehaviour
{
    [SerializeField]
    private GameContext _context;

    [Space, SerializeField]
    private GameInstaller _gamePrefab;
    [SerializeField]
    private LobbyView _lobby;
    [SerializeField]
    private GameOverView _gameOver;

    private GameInstaller _currentGameRoot;

    void Start()
    {
        _lobby.Show();
        _gameOver.Hide();

        _lobby.OnPlay += () =>
        {
            _lobby.Hide();
            StartGame();
        };

        _gameOver.OnLobby += () =>
        {
            EndGame();
            _lobby.Show();
        };

        _gameOver.OnRestart += () =>
        {
            _gameOver.Hide();
            StartGame();
        };
    }

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        if (_currentGameRoot != null)
            EndGame();

        _currentGameRoot = Instantiate(_gamePrefab).Init(_context);
        _currentGameRoot.Game.OnGameOver += () => _gameOver.Show();
    }

    [ContextMenu("End Game")]
    public void EndGame() => Destroy(_currentGameRoot.gameObject);
}
