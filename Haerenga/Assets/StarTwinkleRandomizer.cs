using UnityEngine;

public class StarTwinkleRandomizer : MonoBehaviour
{
    private Animator animator;

    [Header("Random Speed Settings")]
    [SerializeField] private float minSpeed = 0.6f;
    [SerializeField] private float maxSpeed = 1.4f;

    [Header("Random Start Offset")]
    [SerializeField] private bool randomizeStartTime = true;

    [Header("Random Scale")]
    [SerializeField] private float minScale = 0.3f;
    [SerializeField] private float maxScale = 0.7f;

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (animator != null)
        {
            RandomizeTwinkle();
        }

        // Random scale
        float randomScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(randomScale, randomScale, 1f);
    }

    private void RandomizeTwinkle()
    {
        // Random animation speed
        animator.speed = Random.Range(minSpeed, maxSpeed);

        // Randomize animation starting position
        if (randomizeStartTime)
        {
            AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

            animator.Play(state.fullPathHash, 0, Random.Range(0f, 1f));
        }
    }
}