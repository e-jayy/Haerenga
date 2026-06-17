using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

public class SideBouncePad : MonoBehaviour
{
    [FormerlySerializedAs("bounceForce")]
    [Header("Bounce Settings")]
    [SerializeField] private AudioClip bounceAudio;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float bounceForceUp;

    [SerializeField] private float bounceForceSideways;

    [SerializeField] private float bouncePadTimer;

    [Tooltip("Checked = bounce right, Unchecked = bounce left")]
    [SerializeField] private bool bounceRight = true;

    private PlayerController player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        // Cache player reference from the triggered collider
        player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            player.SetBouncePadDurationHorizontal(bouncePadTimer);
            PlayBounceAudio();
            StartCoroutine(hasBouncedCoroutine());
        }

        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb == null)
            return;

        // Reset horizontal velocity for consistent bounce
        rb.linearVelocity = Vector2.zero;

        // Apply upward impulse
        rb.AddForce(Vector2.up * bounceForceUp, ForceMode2D.Impulse);

        float direction = bounceRight ? 1f : -1f;

        // Force exact sideways launch (most reliable method)
        rb.AddForce(Vector2.right * direction * bounceForceSideways, ForceMode2D.Impulse);
    }

    private IEnumerator hasBouncedCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        if (player != null)
            player.hasBounced = true;
    }

    public void PlayBounceAudio()
    {
        audioSource.pitch = Random.Range(0.6f, 0.9f);
        audioSource.PlayOneShot(bounceAudio);
    }
}