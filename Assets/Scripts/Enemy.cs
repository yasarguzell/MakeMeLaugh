using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5f;
    public float followSpeed = 3f;
    public int enemyHp = 3;

    private bool isFollowingPlayer = false;

    void Update()
    {
        // Check if the player is within the detection range
        float distanceToPlayer = Mathf.Abs(player.position.x - transform.position.x);

        if (distanceToPlayer < detectionRange)
        {
            // Player is within detection range, start following
            isFollowingPlayer = true;
        }
        else
        {
            // Player is outside detection range, stop following
            isFollowingPlayer = false;
        }

        // Follow the player if required
        if (isFollowingPlayer)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // Calculate the direction to move towards the player only along the x-axis
        float moveDirection = (player.position.x > transform.position.x) ? 1f : -1f;

        // Move the enemy towards the player
        transform.Translate(new Vector3(moveDirection, 0f, 0f) * followSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            enemyHp--;
            if (enemyHp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
