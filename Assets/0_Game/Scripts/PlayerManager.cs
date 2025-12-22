//using Unity.VisualScripting;
//using UnityEngine;

//public class PlayerManager2 : MonoBehaviour
//{
//    private Transform ball;
//    [SerializeField] private Transform path;

//    private Vector3 startMousePos, startBallPos;
//    private bool moveTheBall;
//    [Range(0f, 1f)] public float maxSpeed;
//    [Range(0f, 1f)] public float camSpeed;
//    [Range(0f, 50f)] public float pathSpeed;
//    private Camera mainCam;
//    private float velocity, camVelocityX, camVelocityY;

//    private Rigidbody rb;
//    private Collider col;
//    private Renderer ballRender;
//    public ParticleSystem collsion;
//    public ParticleSystem air;
//    public ParticleSystem Dust;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        ball = transform;
//        mainCam = Camera.main;
//        rb = GetComponent<Rigidbody>();
//        col = GetComponent<Collider>();
//        ballRender = GetComponent<Renderer>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0) && MenuManager1.Instance.GameState)
//        {
//            moveTheBall = true;
//            Plane newPlane = new Plane(Vector3.up, 0f);
//            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//            if(newPlane.Raycast(ray, out var distance))
//            {
//                startMousePos = ray.GetPoint(distance);
//                startBallPos = ball.position;
//            }
//        }
//        else if(Input.GetMouseButtonUp(0))
//        {
//            moveTheBall = false;
//        }

//        if (moveTheBall)
//        {
//            Plane newPlane = new Plane(Vector3.up, 0f);
//            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//            if (newPlane.Raycast(ray, out var distance))
//            {
//                Vector3 mouseNewPos = ray.GetPoint(distance);
//                Vector3 mouseNewPoss = mouseNewPos - startMousePos;
//                Vector3 desiredPos = mouseNewPoss + mouseNewPoss;

//                desiredPos.x = Mathf.Clamp(desiredPos.x, -1.5f, 1.5f);

//                ball.position = new Vector3(Mathf.SmoothDamp(ball.position.x, desiredPos.x, ref velocity, maxSpeed)
//                , ball.position.y, ball.position.z);
//            }
//        }
//        if(MenuManager1.Instance.GameState)
//        {
//            var pathNewPos = path.position;
//            path.position = new Vector3(pathNewPos.x, pathNewPos.y, Mathf.MoveTowards(pathNewPos.z, -1000f, pathSpeed * Time.deltaTime));
//        }
//    }
        

//    private void LateUpdate()
//    {
//        var CameraNewPos = mainCam.transform.position;
//        if (rb.isKinematic)
//            mainCam.transform.position = new Vector3(Mathf.SmoothDamp(CameraNewPos.x, ball.transform.position.x, ref camVelocityX, camSpeed),
//                Mathf.SmoothDamp(CameraNewPos.y, ball.transform.position.y + 3f, ref camVelocityY, camSpeed), CameraNewPos.z);
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Obstacle"))
//        {
//            gameObject.SetActive(false);
//            MenuManager1.Instance.GameState = false;
//        }

//        if (other.CompareTag("Red"))
//        {
//            other.gameObject.SetActive(false);
//            ballRender.material = other.GetComponent<Renderer>().material;
//            var newParticle = Instantiate(collsion, transform.position, Quaternion.identity);
//            newParticle.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;

//        }
//        else if (other.CompareTag("Blue"))
//        {
//            other.gameObject.SetActive(false);
//            ballRender.material = other.GetComponent<Renderer>().material;
//            var newParticle = Instantiate(collsion, transform.position, Quaternion.identity);
//            newParticle.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;

//        }
//        else if (other.CompareTag("Green"))
//        {
//            other.gameObject.SetActive(false);
//            ballRender.material = other.GetComponent<Renderer>().material;
//            var newParticle = Instantiate(collsion, transform.position, Quaternion.identity);
//            newParticle.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;

//        }
//        else if (other.CompareTag("Yellow"))
//        {
//            other.gameObject.SetActive(false);
//            ballRender.material = other.GetComponent<Renderer>().material;
//            var newParticle = Instantiate(collsion, transform.position, Quaternion.identity);
//            newParticle.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;

//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("path"))
//        {
//            rb.isKinematic = false;
//            col.isTrigger = false;
//            rb.linearVelocity = new Vector3(0f, 8f, 0f);
//            pathSpeed = pathSpeed * 2;

//            var airEff = air.main;
//            airEff.simulationSpeed = 10f;
//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("path"))
//        {
//            rb.isKinematic = true;
//            col.isTrigger = true;
//            pathSpeed = pathSpeed /2;

//            var airEff = air.main;
//            airEff.simulationSpeed = 3f;

//            Dust.transform.position = collision.contacts[0].point + new Vector3(0f, 0.5f, 0f);
//            Dust.GetComponent<Renderer>().material = ballRender.material;
//            Dust.Play();
//        }
//    }
//}
