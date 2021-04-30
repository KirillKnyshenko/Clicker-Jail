using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PanelScript : MonoBehaviour {
    public Text info;
    public Image img;
    public int id;
    public ManegerScript1 ms;
    public MainScript mas;
    public void Start()
    {
        ms = FindObjectOfType<ManegerScript1>();
        mas = FindObjectOfType<MainScript>();
        img.sprite = ms.panels[id].ima;
        for (int i = 0; i < ms.panels[id].value; i++)
        {
            ms.panels[id].price += (20 * (ms.panels[id].price / 100));
        }
    }
    public void Update()
    {
        if  (mas.language == 1)
        {
            info.text =ms.panels[id].name1 +  ". \n Стоимость: " + ms.panels[id].price + " \n Количество:  " + ms.panels[id].value + ". \n Даёт:  " + ms.panels[id].taps + " .";
        }
        if (mas.language == 0)
        {
            info.text = ms.panels[id].name + ". \n Price: " + ms.panels[id].price + " \n Count:  " + ms.panels[id].value + ". \n Add:  " + ms.panels[id].taps +" .";
        }
    }
    public void Buy()
    {
        if (mas.baks >= ms.panels[id].price)
        {
            mas.baks -= ms.panels[id].price;
            ms.panels[id].price += (20 * (ms.panels[id].price / 100));
            ms.panels[id].value++;
        }
    }
}
