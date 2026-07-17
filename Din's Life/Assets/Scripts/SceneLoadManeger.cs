using System.Collections;
using UnityEngine;

public class SceneTransitionController : MonoBehaviour
{
    [Header("Transição automática")]
    [SerializeField] private bool autoLoadNextScene;

    [SerializeField] private string nextSceneName;

    [SerializeField] private float secondsToWait;

    private Coroutine autoLoadCoroutine;

    private void Start()
    {
        if (autoLoadNextScene)
        {
            autoLoadCoroutine = StartCoroutine(AutoLoadScene());
        }
    }

    private IEnumerator AutoLoadScene()
    {
        Debug.Log("[SceneTransitionController] Saindo automaticamente em " + secondsToWait + " segundos para: " + nextSceneName);

        yield return new WaitForSeconds(secondsToWait);

        GameManager.Instance.LoadScene(nextSceneName);
    }

    public void LoadSceneByButton(string sceneName)
    {
        StopAutoLoad();

        GameManager.Instance.LoadScene(sceneName);
    }

    private void StopAutoLoad()
    {
        if (autoLoadCoroutine != null)
        {
            StopCoroutine(autoLoadCoroutine);
            autoLoadCoroutine = null;
        }
    }
}