using UnityEngine;
using UnityEngine.UI;

public class BollJumper : MonoBehaviour
{
    public float jumpForce;
    public float distanceCheck;

    private int chargeCount = 0;
    private float jumpInterval = .3f;
    private float lastJumpTime;
    public bool isCharged = false;

    public Transform checkPlatformLeft;
    public Transform checkPlatformRight;

    public LayerMask platformLayer;
    private RaycastHit hit;
    public GameObject splashPaint;
    public ParticleSystem paintDrops;
    private Rigidbody rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        lastJumpTime = Time.time;
        platformLayer = 1 << 6;
    }

    private void FixedUpdate()
    {
        CheckCharge();
        CheckPlatform();
    }

    private void Jump()
    {
        if (Time.time > lastJumpTime + jumpInterval)
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            lastJumpTime = Time.time;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChargeTrigger"))
        {
            chargeCount++;
            other.GetComponentInParent<Platform>().Break();
            GameManager.instance.platformPassing.Invoke();
        }
    }

    private void CheckPlatform()
    {
        if (Physics.Raycast(checkPlatformLeft.position, Vector3.down, out hit, distanceCheck, platformLayer) || Physics.Raycast(checkPlatformRight.position, Vector3.down, out hit, distanceCheck, platformLayer))
        {
            if(hit.transform.CompareTag("Normal"))
            {
                Jump();
                SpawnEffects(hit.point + new Vector3(0, 0.01f, 0));

                if (isCharged)
                {
                    hit.transform.GetComponentInParent<Platform>().Break();
                    GameManager.instance.platformPassing.Invoke();
                } 
                chargeCount = 0;
            }
            if (hit.transform.CompareTag("Death"))
            {
                if (isCharged)
                {
                    hit.transform.GetComponentInParent<Platform>().Break();
                    chargeCount = 0;
                }
                else GameManager.instance.gameOverEvent.Invoke();
            }
            if (hit.transform.CompareTag("Final"))
            {
                chargeCount = 0;
                isCharged = false;
                GameManager.instance.victoryEvent.Invoke();
            }
        }
    }

    
    private void SpawnEffects(Vector3 position)
    {
        GameObject Splash = Instantiate(splashPaint, position, Quaternion.Euler(90, Random.Range(0, 360), 0));
        Splash.transform.parent = hit.transform;
        Instantiate(paintDrops, position, Quaternion.Euler(-90, 0, 0));
    }

    private void CheckCharge()
    {
        isCharged = (chargeCount > 2) ? true : false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(checkPlatformLeft.position, checkPlatformLeft.position - new Vector3(0,distanceCheck,0));
        Gizmos.DrawLine(checkPlatformRight.position, checkPlatformRight.position - new Vector3(0, distanceCheck, 0));
    }
}
