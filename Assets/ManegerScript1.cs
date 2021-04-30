using System.Collections.Generic;
using UnityEngine;

public class ManegerScript1 : MonoBehaviour
{
    public List<Panels> panels;
    public GameObject panel;
    public Transform content;
    public void Start()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            GameObject g = (GameObject)Instantiate(panel, content);
            PanelScript p = g.GetComponent<PanelScript>();
            p.img.sprite = panels[i].ima;
            p.id = i;
            g.active = true;
        }
    }
}
[System.Serializable]
public class Panels
{
    public string name;
    public string name1;
    public Sprite ima;
    public float price;
    public int value;
    public float taps;
    public bool autoclick;
}