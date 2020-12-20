using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Speed")]
    public float speed = 3f;

    public Vector2 limitX = new Vector2(0, 170f);
    public Vector2 limitY = new Vector2(0, 3.5f);

    private void Track()
    {
        Vector3 posCurr = transform.position;
        Vector3 posTarget = target.position;

        posTarget.x = Mathf.Clamp(posTarget.x, limitX.x, limitX.y);
        posTarget.y = Mathf.Clamp(posTarget.y, limitY.x, limitY.y);
        posTarget.z = -10;

        posCurr = Vector3.Lerp(posCurr, posTarget, speed * Time.deltaTime);
        transform.position = posCurr;
    }

    private void Update()
    {

    }

    private void LateUpdate()
    {
        Track();
    }

}
