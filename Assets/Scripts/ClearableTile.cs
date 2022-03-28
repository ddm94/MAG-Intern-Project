using System.Collections;
using UnityEngine;

public class ClearableTile : MonoBehaviour
{
    // Variables
    public AnimationClip clearAnimation;

    private bool isBeingCleared = false;

    protected Tile tile;

    // Getters & Setters
    public bool IsBeingCleared { get { return isBeingCleared; } }

    private void Awake()
    {
        tile = GetComponent<Tile>();
    }

    public void Clear()
    {
        isBeingCleared = true;
        StartCoroutine(ClearAnimationCoroutine());
    }

    private IEnumerator ClearAnimationCoroutine()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
            animator.Play(clearAnimation.name);

        yield return new WaitForSeconds(clearAnimation.length);

        Destroy(gameObject);
    }
}
