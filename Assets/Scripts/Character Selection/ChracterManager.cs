using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChracterManager : MonoBehaviour
{
    
    void Start()
    {
        if(!PlayerPrefs.HasKey("SelectedOption"))
        {
            LoadGame();
        }
        else
        {
            selectedOption = 0;
        }
        UpdateCharacter( selectedOption);
    }

    public CharacterDbs characterDbs;
    public SpriteRenderer characterPrefab;
    public TMP_Text characterName;
    private int selectedOption = 0;

    public void NextOption()
    {
        selectedOption++;
        if(selectedOption >= characterDbs.CharacterCount)
        {
            selectedOption = 0;
        }
        UpdateCharacter( selectedOption);
        Save();
        
    }
    public void BackOption()
    {
        selectedOption--;
        if(selectedOption < 0)
        {
            selectedOption = characterDbs.CharacterCount - 1;
        }
        UpdateCharacter( selectedOption);
        Save();
    }
    public void UpdateCharacter(int selectedOption)
    {
        Character character  = characterDbs.GetCharacter(selectedOption);
        characterPrefab.sprite = character.characterPrefab;
        characterName.text = character.characterName;
        
    }
    public void LoadGame()
    {
        selectedOption = PlayerPrefs.GetInt("SelectedOption");
    }
    public void Save()
    {
        PlayerPrefs.SetInt("SelectedOption", selectedOption);
    }
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
