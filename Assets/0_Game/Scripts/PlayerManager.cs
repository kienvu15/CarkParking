using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Transform ball;
    [SerializeField] private Transform path;

    private Vector3 startMousePos, startBallPos;
    private bool moveTheBall;
    [Range(0f, 1f)] public float maxSpeed;
    [Range(0f, 1f)] public float camSpeed;
    [Range(0f, 50f)] public float pathSpeed;
    private Camera mainCam;
    private float velocity, camVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = transform;
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && MenuManager.Instance.GameState)
        {
            moveTheBall = true;
            Plane newPlane = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(newPlane.Raycast(ray, out var distance))
            {
                startMousePos = ray.GetPoint(distance);
                startBallPos = ball.position;
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            moveTheBall = false;
        }

        if (moveTheBall)
        {
            Plane newPlane = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlane.Raycast(ray, out var distance))
            {
                Vector3 mouseNewPos = ray.GetPoint(distance);
                Vector3 mouseNewPoss = mouseNewPos - startMousePos;
                Vector3 desiredPos = mouseNewPoss + mouseNewPoss;

                desiredPos.x = Mathf.Clamp(desiredPos.x, -1.5f, 1.5f);

                ball.position = new Vector3(Mathf.SmoothDamp(ball.position.x, desiredPos.x, ref velocity, maxSpeed)
                , ball.position.y, ball.position.z);
            }
        }
        if(MenuManager.Instance.GameState)
        {
            var pathNewPos = path.position;
            path.position = new Vector3(pathNewPos.x, pathNewPos.y, Mathf.MoveTowards(pathNewPos.z, -1000f, pathSpeed * Time.deltaTime));
        }
    }
        

    private void LateUpdate()
    {
        var CameraNewPos = mainCam.transform.position;
        mainCam.transform.position = new Vector3(Mathf.SmoothDamp(CameraNewPos.x, ball.transform.position.x, ref camVelocity, camSpeed), CameraNewPos.y, CameraNewPos.z);
    }
}
