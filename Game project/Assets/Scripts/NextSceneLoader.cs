using UnityEngine;
using UnityEngine.SceneManagement;  // Zorg ervoor dat je SceneManagement toevoegt

public class NextSceneLoader : MonoBehaviour
{
    // Maak de LoadScene functie public zodat deze kan worden aangeroepen door de knoppen in de UI
    public void LoadScene(string sceneName)
    {
        // Laadt de scène met de naam die je hebt ingevoerd
        SceneManager.LoadScene(sceneName);
    }
}
