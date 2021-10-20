using TMPro;
using UnityEngine;

namespace Etched
{
    public class TemporaryWordDisplay : MonoBehaviour
    {
        TextMeshProUGUI previewText;

        void Awake()
        {
            previewText = GetComponent<TextMeshProUGUI>();
        }
        void OnEnable()
        {
            LineInterpreter.OnLinePositionsUpdated += GetWord;
            InputHandler.OnRelease += OnRelease;
        }

        void OnRelease(DragInformation drag)
        {
            UpdateText("");
        }

        void OnDisable()
        {
            LineInterpreter.OnLinePositionsUpdated -= GetWord;
        }

        void GetWord(LineInterpreter lineInterpreter)
        {
            string word = lineInterpreter.Word;
            UpdateText(word);
        }

        void UpdateText(string word)
        {
            previewText.text = word;
        }
        
        
    }
}