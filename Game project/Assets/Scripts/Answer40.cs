using TMPro;
using UnityEngine;

public class Answer40 : MonoBehaviour
{
    public TMP_InputField inputField; // Koppel het Input Field
    public TextMeshProUGUI feedbackText; // Koppel de feedback tekst
    public string correctAnswer = "40"; // Stel hier het juiste antwoord in

    public void CheckAnswer()
    {
        string userAnswer = inputField.text.Trim(); // Haal de invoer van de gebruiker op en verwijder spaties
        if (userAnswer.Equals(correctAnswer, System.StringComparison.OrdinalIgnoreCase)) // Case-insensitive check
        {
            feedbackText.text = "Correct, please click at next and go to the Work Station!"; // Feedback bij goed antwoord
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "That's a bummer try again please :)!"; // Feedback bij fout antwoord
            feedbackText.color = Color.red;
        }
    }
}
