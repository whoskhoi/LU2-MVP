using TMPro;
using UnityEngine;

public class RenameManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_Text nameDisplayText;

    public void Rename()
    {
        if (!string.IsNullOrWhiteSpace(nameInputField.text))
        {
            nameDisplayText.text = nameInputField.text;
        }
    }
}
