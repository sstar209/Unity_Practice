using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject slotItem;

    void OnTriggerEnter(Collider coll)
    {
        //플레이어와 접촉 시 trigger 발동
        if(coll.tag.Equals("Player"))
        {
            Inventory inven = coll.GetComponent<Inventory>();
            for (int i = 0; i < inven.slots.Count; i++)
            {
                //별 1개 획득 시
                if (inven.slots[0].isEmpty)
                {
                    Instantiate(slotItem, inven.slots[0].slotObj.transform, false);
                    inven.slots[0].isEmpty = false;
                    Destroy(this.gameObject);

                    GameManager.instance.StarOneText();
                    GameManager.instance.AddStar(1);
                    GameManager.instance.ParticlePlay();
                    SoundManager.instance5.StarPickUp();

                    Debug.Log("별 1개");

                    break;
                }

                //별 2개 획득 시
                if (inven.slots[1].isEmpty)
                {
                    Instantiate(slotItem, inven.slots[1].slotObj.transform, false);
                    inven.slots[1].isEmpty = false;
                    Destroy(this.gameObject);

                    GameManager.instance.StarTwoText();
                    GameManager.instance.AddStar(1);
                    GameManager.instance.ParticlePlay();
                    SoundManager.instance5.StarPickUp();

                    Debug.Log("별 2개");

                    break;
                }

                //별 3개 획득 시
                if (inven.slots[2].isEmpty)
                {
                    Instantiate(slotItem, inven.slots[2].slotObj.transform, false);
                    inven.slots[2].isEmpty = false;
                    Destroy(this.gameObject);

                    GameManager.instance.StarThreeText();
                    GameManager.instance.AddStar(1);
                    GameManager.instance.ParticlePlay();
                    SoundManager.instance5.StarPickUp();

                    Debug.Log("별 3개");

                    break;
                }

                //별 4개 획득 시
                if (inven.slots[3].isEmpty)
                {
                    Instantiate(slotItem, inven.slots[3].slotObj.transform, false);
                    inven.slots[3].isEmpty = false;
                    Destroy(this.gameObject);

                    GameManager.instance.StarFourText();
                    GameManager.instance.AddStar(1);
                    GameManager.instance.ParticlePlay();
                    SoundManager.instance5.StarPickUp();

                    Debug.Log("별 4개");

                    break;
                }

                //별 5개 획득 시
                if (inven.slots[4].isEmpty)
                {
                    Instantiate(slotItem, inven.slots[4].slotObj.transform, false);
                    inven.slots[4].isEmpty = false;
                    Destroy(this.gameObject);

                    GameManager.instance.StarFiveText();
                    GameManager.instance.AddStar(1);
                    GameManager.instance.ParticlePlay();
                    SoundManager.instance5.StarPickUp();

                    Debug.Log("별 5개");

                    BossSpawn.instance2.SpawnMonster();
                    break;
                }
            }
        }
    }
}
