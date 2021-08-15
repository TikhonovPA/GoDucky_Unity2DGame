using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _music;
    private void Start()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Music");
        if (objects.Length == 0)
        {
            GameObject inst_obj = Instantiate(_music, new Vector2(0, 0), Quaternion.identity) as GameObject;
            DontDestroyOnLoad(inst_obj);
        }
    }
}
