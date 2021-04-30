using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextStrimer : MonoBehaviour
{
    public string rus;
    public string eng;
    MainScript MS;
    Text Clikc;
    public void Start()
    {
        MS = FindObjectOfType<MainScript>();
        Clikc = GetComponent<Text>();
    }
    public void Update()
    {
    if (MS.language == 1)
    {
    Clikc.text = rus;
     }
     if (MS.language == 0)
     {
     Clikc.text = eng;
     }
    }
}