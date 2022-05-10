using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextAnamation : MonoBehaviour
{
    public TMP_Text Text;
    private string text;
    
    // Start is called before the first frame update
    void Start()
    {
        //text = GetComponent<TextMeshPro>().text;
        text = Text.text;
        //GetComponent<TextMeshPro>().text = "";
        Text.text = "";
        StartCoroutine(TextCoroutine());
    }
    IEnumerator TextCoroutine()
    {
        foreach(char abc in text)
        {

            Text.text += abc;
            yield return new WaitForSeconds(0.08f);
        }
    }
}
