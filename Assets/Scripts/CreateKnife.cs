using UnityEngine;
using System.Collections;

public class CreateKnife : MonoBehaviour
{
    [SerializeField] private float waitTime = 1f;
    [SerializeField] GameObject knife;
    private bool isSpawn;
    private Coroutine spawn;
    private void Update()
    {
        if (StartGame.isStart && !isSpawn)
        {
            spawn = StartCoroutine(SpawnKnives());
            isSpawn = true;
        }
    }
    IEnumerator SpawnKnives()
    {
        while (true)
        {
            if (StartGame.isStart)
            {
                Instantiate(
                    knife,
                    new Vector2(6f, Random.Range(-3.23f, -1f)),
                    Quaternion.Euler(0, 0, -45));
            }
            else 
                StopCoroutine(spawn);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
