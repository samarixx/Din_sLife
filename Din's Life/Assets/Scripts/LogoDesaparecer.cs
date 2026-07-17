using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SplashFade : MonoBehaviour
{
    [Header("Referência da Splash")]
    public Graphic splashGraphic;

    [Header("Tempos")]
    public float fadeInTime = 2f;
    public float stayTime = 1f;
    public float fadeOutTime = 2f;

    [Header("Escala")]
    public Vector3 initialScale = Vector3.one;
    public Vector3 finalScale = Vector3.zero;

    private void Start()
    {
        if (splashGraphic == null)
        {
            Debug.LogError("Nenhuma Image ou RawImage foi atribuída!");
            return;
        }

        StartCoroutine(FadeSequence());
    }

    IEnumerator FadeSequence()
    {
        Color color = splashGraphic.color;
        
        color.a = 0f;
        splashGraphic.color = color;

        splashGraphic.rectTransform.localScale = initialScale;
        
        float timer = 0f;

        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;

            float progress = timer / fadeInTime;
            
            color.a = Mathf.Lerp(0f, 1f, progress);
            splashGraphic.color = color;

            yield return null;
        }
        
        color.a = 1f;
        splashGraphic.color = color;
        
        yield return new WaitForSeconds(stayTime);
        
        timer = 0f;

        while (timer < fadeOutTime)
        {
            timer += Time.deltaTime;

            float progress = timer / fadeOutTime;
            
            color.a = Mathf.Lerp(1f, 0f, progress);
            splashGraphic.color = color;
            
            splashGraphic.rectTransform.localScale =
                Vector3.Lerp(initialScale, finalScale, progress);

            yield return null;
        }
        
        color.a = 0f;
        splashGraphic.color = color;

        splashGraphic.rectTransform.localScale = finalScale;
    }
}