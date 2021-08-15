using UnityEngine;
using System.Collections;

public class CreateSounds : MonoBehaviour
{
    [SerializeField] private float waitTime = 3f;
    private bool isSpawn;
    private Coroutine spawn;
    private AudioSource duckAudio;
    private void Start()
    {
        duckAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (StartGame.isStart && !isSpawn)
        {
            spawn = StartCoroutine(SpawnAudio());
            isSpawn = true;
        }
    }
    IEnumerator SpawnAudio()
    {
        while (true)
        {
            if (StartGame.isStart)
                duckAudio.Play();
            else
                StopCoroutine(spawn);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
