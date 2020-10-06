using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject monsterRabbit;
    public GameObject monsterMummy;

    public float timeGap = 3f;
    public Transform[] spawnPositions;  //spawn할 지점은 몇 군데?

    void Start()
    {
        GameManager.instance.onPlay += PlayGame;
    }

    void PlayGame()
    {
        //timeGap(3초)만큼 시간이 지난 후 최초로 SpawnMonster 함수를 호출하고
        //시간이 timeGap만큼 지날 떄마다 반복 호출

        InvokeRepeating("SpawnMonster", timeGap, timeGap);
    }

    void SpawnMonster()
    {
        //몬스터가 나오는 장소를 랜덤으로 설정
        int spawnIndex = Random.Range(0, spawnPositions.Length);

        //Instantiate 함수를 사용하여 Prefabs폴더에 있는 Rabbit를 생성하여 Scene에 배치
        //GameManager의 pickUpStar가 증가할 수록 아래의 조건문이 발생

        if(GameManager.instance.pickUpStar == 0)
        {
            //슬라임 1
            Instantiate(monsterRabbit, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
            Debug.Log("1라운드");
        }

        if(GameManager.instance.pickUpStar == 1)
        {
            //슬라임 2
            Instantiate(monsterRabbit, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
            Instantiate(monsterRabbit, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
            Debug.Log("2라운드");
        }

        if (GameManager.instance.pickUpStar == 2)
        {
            //슬라임 1, 미라 1
            Instantiate(monsterRabbit, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
            Instantiate(monsterMummy, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
            Debug.Log("3라운드");
        }

        if (GameManager.instance.pickUpStar == 3)
        {
            //미라 2
            Instantiate(monsterMummy, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
            Instantiate(monsterMummy, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
            Debug.Log("4라운드");
        }

        if (GameManager.instance.pickUpStar == 4)
        {
            //슬라임 2, 미라 2
            Instantiate(monsterRabbit, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
            Instantiate(monsterRabbit, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
            Instantiate(monsterMummy, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
            Instantiate(monsterMummy, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
            Debug.Log("5라운드");
        }
    }
}
