using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootCreater : MonoBehaviour
{
    public GameObject loot;
    public float soulsSayisi;
    private GameObject lootObject;
    public void createLoot()
    {
        lootObject = Instantiate(loot,this.transform.position,Quaternion.identity);
        lootObject.GetComponent<lootController>().soulsSayisi = soulsSayisi;
    }
}
