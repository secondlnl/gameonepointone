using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour
{
    [SerializeField] private GameObject CreditsPanel;
    [SerializeField] private GameObject LevelPanel;
    [SerializeField] private GameObject QuitPanel;
    [SerializeField] private GameObject LevelOneButton;
    [SerializeField] private GameObject LevelTwoButton;
    [SerializeField] private GameObject LevelThreeButton;
    [SerializeField] private GameObject LevelFourButton;
    [SerializeField] private GameObject LevelFiveButton;
    [SerializeField] private int[] unlocked; // Contains the lvls unlocked 

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ShowCredits()
    {
        CreditsPanel.SetActive(true);
    }
    public void CloseCredits()
    {
        CreditsPanel.SetActive(false);
    }
    public void ShowLevelPanel() { LevelPanel.SetActive(true); }
    public void CloseLevelPanel() { LevelPanel.SetActive(false); }
    public void ShowQuitPanel() { QuitPanel.SetActive(true); }
    public void CloseQuitPanel() { QuitPanel.SetActive(false); }
    private bool Locked(int lvllocked)
    {
        bool returnval = false;
        switch (lvllocked)
        {
            case 1:
                returnval = LevelOneButton.GetComponentsInChildren<Lock>()[0].locked;
                break;
            case 2:
                LevelTwoButton.GetComponentInChildren<Lock>().locked = returnval;
                break;
            case 3:
                LevelThreeButton.GetComponentInChildren<Lock>().locked = returnval;
                break;
            case 4:
                LevelFourButton.GetComponentInChildren<Lock>().locked = returnval;
                break;
            case 5:
                LevelFiveButton.GetComponentInChildren<Lock>().locked = returnval;
                break;
            default:
                break;
        }
        return returnval;
    }

    public void LoadLevel(int lvl)
    {
        if (Locked(lvl) == false)
            SceneManager.LoadScene(lvl);
    }
}
