using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndScreen : MonoBehaviour
{
    public Text mainText;      // drag your UI Text here
    public Text subText;       // smaller text below
    public Button menuButton;  // drag your button here

    void Start()
    {
        menuButton.gameObject.SetActive(false);
        subText.gameObject.SetActive(false);
        StartCoroutine(PlayEnding());
    }

    IEnumerator PlayEnding()
    {
        mainText.text = "";
        yield return new WaitForSeconds(0.5f);

        // glitch text effect
        string[] glitchFrames = { "Y0U 3SC@P3D", "YØU ESCÅPED", "YOU ESCAPED THE GLITCH" };
        foreach (string frame in glitchFrames)
        {
            mainText.text = frame;
            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(1f);
        subText.gameObject.SetActive(true);
        subText.text = "The world couldn't hold you.";

        yield return new WaitForSeconds(1.5f);
        menuButton.gameObject.SetActive(true);
    }

    public void GoToMenu()
    {
        GameManager.hasEscaped = false;
        SceneManager.LoadScene("GameScene"); // or your main menu scene
    }
}