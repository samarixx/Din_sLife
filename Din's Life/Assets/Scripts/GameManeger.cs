using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        Iniciando,
        Splash,
        MenuPrincipal,
        Gameplay
    }

    [Header("Estado atual")]
    [SerializeField] private GameState currentState;

    [Header("Input")]
    [SerializeField] private PlayerInput playerInput;

    public GameState CurrentState => currentState;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        Debug.Log("[GameManager] Iniciado.");
        Debug.Log("[GameManager] Cena inicial: " + SceneManager.GetActiveScene().name);

        ChangeStateBySceneName(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("[GameManager] Entrou na cena: " + scene.name);

        ChangeStateBySceneName(scene.name);
    }

    private void ChangeStateBySceneName(string sceneName)
    {
        switch (sceneName)
        {
            case "_Boot":
                ChangeState(GameState.Iniciando);
                break;

            case "Splash":
                ChangeState(GameState.Splash);
                break;

            case "MenuPrincipal":
                ChangeState(GameState.MenuPrincipal);
                break;

            case "GetStarted_Scene":
                ChangeState(GameState.Gameplay);
                break;

            default:
                Debug.LogWarning("[GameManager] Cena sem estado definido: " + sceneName);
                break;
        }
    }

    public void LoadScene(string sceneName)
    {
        Debug.Log("[GameManager] Saindo da cena: " + SceneManager.GetActiveScene().name);
        Debug.Log("[GameManager] Carregando cena: " + sceneName);

        SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void AssignPlayerInput(PlayerInput input)
    {
        playerInput = input;

        Debug.Log("[GameManager] Input atribuído ao jogador.");
    }

    public void QuitGame()
    {
        Debug.Log("[GameManager] Saindo do jogo.");

        Application.Quit();
    }

    private void ChangeState(GameState newState)
    {
        currentState = newState;

        Debug.Log("[GameManager] Estado atual: " + currentState);
    }
}