using UnityEngine;
using TMPro;
using System.Collections;

public class End : MonoBehaviour
{
    public TMP_Text mainText;
    public TMP_Text subText;

    void Start()
    {
        subText.gameObject.SetActive(false);
        StartCoroutine(PlayEnding());
    }

    IEnumerator PlayEnding()
    {
        mainText.text = "";
        yield return new WaitForSeconds(0.5f);

        string[] glitchFrames = { "Y0U 3SC@P3D", "YØU ESCÅPED", "YOU ESCAPED THE GLITCH" };
        foreach (string frame in glitchFrames)
        {
            mainText.text = frame;
            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(1f);
        subText.gameObject.SetActive(true);
        subText.text = "The world couldn't hold you.";
    }
}