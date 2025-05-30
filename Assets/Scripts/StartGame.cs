using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGame : MonoBehaviour
{
    GameObject mommySpaceship;
    GameObject startText;
    Animator animator;
    [SerializeField] GameObject playerSpawnPoint;
    [SerializeField] GameObject player;
    GameObject spawnedPlayer; // Переменная для хранения ссылки на инстанцированного игрока
    public AudioClip startSound;
    private AudioSource audioSource;

    private void Start()
    {
        mommySpaceship = GameObject.Find("MommySpaceship");
        startText = GameObject.Find("StartText");
        animator = mommySpaceship.GetComponent<Animator>();
        // Получаем компонент AudioSource
        audioSource = GetComponent<AudioSource>();

        // Убедитесь, что аудиоклип установлен
        if (startSound == null)
        {
            Debug.LogError("Explosion sound is not assigned!");
        }

        if (mommySpaceship == null)
        {
            Debug.LogError("MommySpaceship not found!");
        }
        if (startText == null)
        {
            Debug.LogError("StartText not found!");
        }
        if (animator == null)
        {
            Debug.LogError("Animator component not found on MommySpaceship!");
        }
    }
    void PlayStartSound()
    {
        if (audioSource != null && startSound != null)
        {
            audioSource.PlayOneShot(startSound);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))  // Проверяем, была ли нажата клавиша
        {
            startText.SetActive(false);
            StartCoroutine(MoveMommySpaceship());
            PlayStartSound();
        }
    }

    IEnumerator MoveMommySpaceship()
    {
        while (mommySpaceship.transform.position.y >= -9.18f)
        {
            mommySpaceship.transform.position += new Vector3(0, -0.1f, 0);
            yield return new WaitForSeconds(0.08f);  // Ждём 0.08 секунды перед следующим шагом
        }
        SpawnPlayer();
        animator.SetTrigger("isOnPosition");
        StartCoroutine(MovePlayer());
    }

    IEnumerator MovePlayer()
    {
        if (spawnedPlayer == null)
        {
            Debug.LogError("Spawned player is null!");
            yield break;
        }

        while (spawnedPlayer.transform.position.y <= -6.50f)
        {
            spawnedPlayer.transform.position += new Vector3(0, 0.2f, 0);
            yield return new WaitForSeconds(0.08f);  // Ждём 0.08 секунды перед следующим шагом
        }
        SceneManager.LoadScene("MainScene");
    }

    void SpawnPlayer()
    {
        float spawnX = playerSpawnPoint.transform.position.x;
        float spawnY = playerSpawnPoint.transform.position.y;
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
        spawnedPlayer = Instantiate(player, spawnPosition, Quaternion.identity);
        if (spawnedPlayer == null)
        {
            Debug.LogError("Failed to spawn player!");
        }
    }
}
