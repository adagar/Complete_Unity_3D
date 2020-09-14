using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField]
    float rcsThrust = 100f;
    [SerializeField]
    float mainThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip successSound;

    Rigidbody rigidBody;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("OK");
                break;
            case "Fuel":
                Debug.Log("REFUEL");
                break;
            case "Goal":
                Debug.Log("VICTORY");
                SceneManager.LoadScene(1);
                break;
            default:
                Debug.Log("DEAD");
                SceneManager.LoadScene(0);
                break;
        }
    }


    private void ProcessInput()
    {
        RespondToThrustInput();
        RespondToRotateInput();
    }

    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ApplyThrust();
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void ApplyThrust()
    {
        float thrustThisFame = mainThrust * Time.deltaTime;
        rigidBody.AddRelativeForce(Vector3.up * thrustThisFame);
        if (!audioSource.isPlaying)
        {
            //audioSource.clip = mainEngine;
            //audioSource.Play();
            audioSource.PlayOneShot(mainEngine, 1.0f);
            Debug.Log("PLAYING AUDIO CLIP");

        }
        Debug.Log(audioSource.isPlaying);
    }

    private void RespondToRotateInput()
    {
        rigidBody.freezeRotation = true;

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false;
    }
}
