using TMPro;
using UnityEngine;

/**
 * This component should be attached to a TextMeshPro object.
 * It allows to feed an integer number to the text field.
 */
[RequireComponent(typeof(TextMeshPro))]
public class NumberField : MonoBehaviour{
    [SerializeField] int number;
    [SerializeField] string text;
    [SerializeField] bool showText;

    public void Start()
    {
        ShowText();
    }

    public int GetNumber(){
        return this.number;
    }

    public void SetNumber(int newNumber){
        this.number = newNumber;
        ShowText();
    }

    public void AddNumber(int toAdd){
        SetNumber(this.number + toAdd);
    }
    public void SubNumber(int toSub)
    {
        SetNumber(this.number - toSub);
    }
    public void ShowText()
    {
        if(showText)
        {
            GetComponent<TextMeshPro>().text = text + this.number.ToString();
        }
    }
}
