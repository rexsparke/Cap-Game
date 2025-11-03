using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("References")]
    public Image Fill;                 // assign the child Image used as the green bar

    private Transform target;          // what we follow
    private HealthSystem health;       // whose health we show
    private Canvas canvas;             // world-space canvas we control

    [Header("Placement")]
    public Vector3 offset = new Vector3(0, 2f, -0.1f);   // a bit above & in front

    private void Awake()
    {
        // Find the Canvas under this prefab
        canvas = GetComponentInChildren<Canvas>(true);

        // Make sure it's set up for world-space UI
        if (canvas != null && canvas.renderMode == RenderMode.WorldSpace)
        {
            if (canvas.worldCamera == null) canvas.worldCamera = Camera.main;
        }

        // Ensure the Fill image will respond to fillAmount
        if (Fill != null)
        {
            Fill.type = Image.Type.Filled;
            Fill.fillMethod = Image.FillMethod.Horizontal; // left -> right
            Fill.fillOrigin = 0;                           // start at left
        }
    }

    public void Initialize(HealthSystem targetHealth)
    {
        health = targetHealth;
        target = targetHealth.transform;

        health.OnHealthChanged.AddListener(UpdateBar);
        UpdateBar(health.CurrentHealth, health.MaxHealth);
    }

    private void UpdateBar(int current, int max)
    {
        if (Fill != null && max > 0)
            Fill.fillAmount = Mathf.Clamp01((float)current / max);
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // Follow the target and keep the bar flat to the 2D camera
        transform.position = target.position + offset;
        transform.rotation = Quaternion.identity; // billboard for 2D
    }

    private void OnDestroy()
    {
        if (health != null)
            health.OnHealthChanged.RemoveListener(UpdateBar);
    }
}
