using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public bool locked = true;
    [SerializeField] int level;
    // Ideally it shouldn't check every frame
    void Start()
    {
        switch (level)
        {
            case 1:
                locked = false;
                break;
            case 2:
                if (PlayerPrefs.GetString("LevelTwo") == "1") locked = false;
                break;
            case 3:
                if (PlayerPrefs.GetString("LevelThree") == "1") locked = false;
                break;
            case 4:
                if (PlayerPrefs.GetString("LevelFour") == "1") locked = false;
                break;
            case 5:
                if (PlayerPrefs.GetString("LevelFive") == "1") locked = false;
                break;
        }
    }
    void Update()
    {
        if (locked == true) { gameObject.GetComponentInParent<Button>().interactable = false; gameObject.GetComponent<Image>().enabled = locked; }
        if (locked == false) { gameObject.GetComponentInParent<Button>().interactable = true; gameObject.GetComponent<Image>().enabled = locked; }
    }
}
