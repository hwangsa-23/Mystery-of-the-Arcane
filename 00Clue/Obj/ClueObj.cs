using UnityEngine;

[CreateAssetMenu(fileName = "NewClue", menuName = "Clue/ClueObj")]
public class ClueObj : ScriptableObject
{
    public string ObjName;
    public Sprite ObjImage;
    public string ObjExp;
}
