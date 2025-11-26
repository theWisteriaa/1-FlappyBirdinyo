using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;



public class LogicScript : MonoBehaviour

{
    
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    private Vector3 originalPos;
    private Vector3 originalScale;



    [ContextMenu ("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
            
        scoreText.text = playerScore.ToString();

        StartCoroutine(ScoreTextEffect());
    }

    private IEnumerator ScoreTextEffect()
    {
        RectTransform rect = scoreText.rectTransform;
        originalPos = rect.localPosition;
        originalScale = rect.localScale;

        float duration = 0.25f;   // toplam süre
        float magnitude = 3f;     // shake þiddeti
        float popScale = 1.2f;    // ne kadar büyüsün
        float elapsed = 0f;

        //  Ýlk anda büyüt
        rect.localScale = originalScale * popScale;

        while (elapsed < duration)
        {
            // shake
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            rect.localPosition = originalPos + new Vector3(x, y, 0);

            // küçülme (pop’tan geri dönme)
            float t = elapsed / duration;
            rect.localScale = Vector3.Lerp(originalScale * popScale, originalScale, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Pozisyon ve ölçek sýfýrla
        rect.localPosition = originalPos;
        rect.localScale = originalScale;

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        
        FindFirstObjectByType<PipeSpawn>().StopSpawning();


    }






}
