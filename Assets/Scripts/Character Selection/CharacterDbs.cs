using UnityEngine;
using System.Collections.Generic;
using System.Collections;


[CreateAssetMenu]
public class CharacterDbs : ScriptableObject
{
    public Character[] characters;
    public int CharacterCount
    {
        get
        {
            return characters.Length;
        }
    }
    public Character GetCharacter(int index)
    {
        return characters[index];
    }

}
