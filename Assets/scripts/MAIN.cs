using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class MAIN : MonoBehaviour
{

    public float speed;
    public int rotation;

    public GameObject gameOverPanel;
    // public Transform carTransform;
    public Text scoreText;
    public int score = 0;
    public float fuel;
    public Slider fuelSlider;
    public static bool isGameRunning = true;
    public static bool fromGameRestart = false;
    public static bool gameStop = false;
    public static MAIN instance;
  

    public static bool puzzleScreen = false;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    //  private Vector3 carRotation = Transform.rotation.eulerAngles;

    // public Vector3 CarRotation { get => carRotation; set => carRotation = value; }

    void Start()
    {

        AudioManager.instance.carEngineAudioSource.Stop();
        Time.timeScale = 1;
        score = 0; // Initialize score counter
        if (fromGameRestart)
        {
            score = 0;
            //Time.timeScale = 1; // Start the game if it is not restarted    
        }
        else
        {
            //Time.timeScale = 0; // Continue the game if it is restarted         
        }
        isGameRunning = true; // Set the game as running 
        scoreText.text = score.ToString();
    }
    void Update()
    {
        fuelUpdate();
    }
    public void fuelUpdate()
    {
        fuel -= Time.deltaTime * 3f;

        fuelSlider.value = fuel; // Assuming fuel is out of 100, adjust as needed
       // AudioManager.instance.stopCarEngine();
        if (fuel <= 0)
        {
           
            gameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("coin1"))
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = score.ToString();
            AudioManager.instance.playCoinSound();

        }
        else if (collision.gameObject.CompareTag("coin5"))
        {
            Destroy(collision.gameObject);
            score += 5;
            scoreText.text = score.ToString();
            AudioManager.instance.playCoinSound();
        }
        else if (collision.gameObject.CompareTag("coin10"))
        {
            Destroy(collision.gameObject);
            score += 10;
            scoreText.text = score.ToString();
            AudioManager.instance.playCoinSound();
        }
        else if (collision.gameObject.CompareTag("fuel"))
        {
            fuel = 100;
            Destroy(collision.gameObject); // Destroy the fuel object
            AudioManager.instance.playFuelSound();
        }
        else if (collision.gameObject.CompareTag("exitarrow"))
        {
            Destroy(collision.gameObject);
            stick ss = collision.transform.parent.gameObject.GetComponentInChildren<stick>(); // Get the stick component from the arrow object
            ss.moreMass(); // Call the RestartGame method from the script instance
        }
        else if (collision.gameObject.CompareTag("A"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("puzzle key"))
        {
            Destroy(collision.gameObject); 
            SceneManager.LoadScene("puzzle-1");
        }
        else if (collision.gameObject.CompareTag("puzzle key 2"))
        {
            Destroy(collision.gameObject); 
            SceneManager.LoadScene("puzzle 2");
        }
        else
        {
            isGameRunning = false; // Set the game as not running
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        fuelSlider.value = 100; // Reset fuel slider to full
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void ShowHome()
    {

        screenManager.instance.ShowLoadAndHome();
    }
    public void gameOver()
    {
       
        gameOverPanel.SetActive(true);
        isGameRunning = false; // Set the game as not running
        
    }
    
}
/*
  if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Game Exited");
        }*/
//public void ResumeGame()
//{
//    gameOverPanel.SetActive(false);
//    Time.timeScale = 1f; // Resume the game
//    Debug.Log("Game Resumed");
//}
//public void LoadMainMenu()
//{
//    UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
//    Debug.Log("Loading Main Menu");
//}
//public void LoadLevel1()
//{
//    UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
//    Debug.Log("Loading Level 1");
//}
//public void LoadLevel2()
//{
//    UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
//    Debug.Log("Loading Level 2");
//}
/*
 public ParticleSystem airEffect;
public LayerMask groundLayer;
public Transform groundCheck;
public float groundCheckRadius = 0.2f;
private bool isGrounded;

void Update()
{
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    if (!isGrounded && !airEffect.isPlaying)
        airEffect.Play();
    else if (isGrounded && airEffect.isPlaying)
        airEffect.Stop();
} 
 */