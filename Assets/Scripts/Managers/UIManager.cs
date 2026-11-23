using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject characterSelect;
    public GameObject trackSelect;

    public void ChangeUI(int uiIndex)
    {
        ResetUI();
        switch (uiIndex)
        {
            case 0:
                mainMenu.SetActive(true);
                break;
            case 1:
                characterSelect.SetActive(true);
                break;
            default:
                trackSelect.SetActive(true);
                break;
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void ResetUI()
    {
        mainMenu.SetActive(false);
        characterSelect.SetActive(false);
        trackSelect.SetActive(false);
    }
}