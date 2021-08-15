using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    [SerializeField] private GameObject exlposion, panelLose;
    [SerializeField] private Color deathColor;
    private SpriteRenderer _sr;
    private AudioSource audioLose;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        audioLose = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Knife"))
        {
            StartGame.isStart = false;
            Destroy(collision.transform.parent.gameObject);
            _sr.color = deathColor;

            ContactPoint2D contact = collision.contacts[0];
            Vector3 pos = contact.point;
            GameObject exp = Instantiate(exlposion, pos, Quaternion.identity) as GameObject;
            Destroy(exp, 1f);

            audioLose.Play();
            panelLose.SetActive(true);
        }
    }
}
