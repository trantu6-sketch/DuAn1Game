using UnityEngine;

/// <summary>
/// Script để test hệ thống HP của Player
/// Có thể gắn vào button UI, object để test, hoặc chỉ cần gọi hàm để test
/// </summary>
public class PlayerDamageTester : MonoBehaviour
{
    [Header("Test Settings")]
    public float damageAmount = 10f;
    public KeyCode testKey = KeyCode.H; // Nhấn H để test nhận sát thương
    
    private PlayerController playerController;

    void Start()
    {
        // Tự động tìm PlayerController trong scene
        playerController = FindFirstObjectByType<PlayerController>();
        
        if (playerController == null)
        {
            Debug.LogWarning("Không tìm thấy PlayerController trong scene!");
        }
    }

    void Update()
    {
        // Test bằng phím (nhấn H để test)
        if (Input.GetKeyDown(testKey) && playerController != null)
        {
            TestTakeDamage();
        }
    }

    /// <summary>
    /// Hàm test nhận sát thương - có thể gọi từ button UI hoặc từ code khác
    /// </summary>
    public void TestTakeDamage()
    {
        if (playerController != null)
        {
            playerController.TakeDamage(damageAmount);
            Debug.Log($"Player nhận {damageAmount} sát thương. HP hiện tại: {playerController.GetCurrentHP()}/{playerController.GetMaxHP()}");
        }
        else
        {
            Debug.LogError("PlayerController không tồn tại!");
        }
    }

    /// <summary>
    /// Hàm test hồi máu - có thể gọi từ button UI
    /// </summary>
    public void TestHeal()
    {
        if (playerController != null)
        {
            playerController.Heal(damageAmount);
            Debug.Log($"Player hồi {damageAmount} HP. HP hiện tại: {playerController.GetCurrentHP()}/{playerController.GetMaxHP()}");
        }
        else
        {
            Debug.LogError("PlayerController không tồn tại!");
        }
    }

    /// <summary>
    /// Test khi va chạm với object (nếu muốn test bằng cách chạm vào object)
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TestTakeDamage();
        }
    }
}

