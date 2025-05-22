using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterWithIndex : MonoBehaviour
{
    public TextMeshProUGUI tmpText; // Your TMP component
    public string fullText;          // The full string to display
    public float delay = 0.05f;      // Delay between each character

    private int currentIndex = 0;
    private bool isTyping = false;

    private void Start()
    {
        tmpText.text = "";  // Clear at start if needed
    }

    public void StartTyping(string textToShow)
    {
        if (isTyping)
            StopAllCoroutines();

        fullText = textToShow;
        currentIndex = 0;
        tmpText.text = "";
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        isTyping = true;

        while (currentIndex < fullText.Length)
        {
            currentIndex++;
            tmpText.text = fullText.Substring(0, currentIndex);
            yield return new WaitForSeconds(delay);
        }

        isTyping = false;
    }

    // Optional: skip typing and show full text immediately
    public void SkipTyping()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            tmpText.text = fullText;
            isTyping = false;
        }
    }
}
