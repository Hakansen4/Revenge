using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class charSoulController : MonoBehaviour
{
    private float soulSayisi;
    public TextMeshProUGUI soulText;
    private void Start()
    {
        soulSayisi = 0;
        soulText.text = soulSayisi.ToString();
    }
    public void addSoul(float sayi)
    {
        soulSayisi += sayi;
        soulText.text = soulSayisi.ToString();
    }
}