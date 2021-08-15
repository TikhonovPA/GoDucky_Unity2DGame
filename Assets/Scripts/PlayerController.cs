using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector2 targetPos;
    private float speed = 5f;
    private void Update()
    {
        if (StartGame.isStart)
        {

#if UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    targetPos = Camera.main.ScreenToWorldPoint(touch.position);
                }
            }
#endif

#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
#endif
            float step = speed * Time.deltaTime;

            if (targetPos.y < -3.2f)
                targetPos.y = -3.2f;

            else if (targetPos.y > -0.5f)
                targetPos.y = -0.5f;

            player.transform.position = Vector3.MoveTowards(
                player.transform.position,
                new Vector2(player.transform.position.x,targetPos.y),
                step);
        }
    }

}
