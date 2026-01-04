using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Player Vehicle")]
    [SerializeField] private Transform player;

    [Header("Camera Base Offset")]
    [SerializeField] private Vector3 offset = new Vector3(0, 4, -9);

    [Header("Dynamic Settings")]
    [SerializeField] private float lateralOffsetMultiplier = 2f;
    [SerializeField] private float lateralSmoothSpeed = 5f; // smoothing uniquement pour le latéral
    [SerializeField] private float pitchAngle = 10f;

    [Header("Reference to Vehicle")]
    [SerializeField] private Vehicle vehicle;

    private float currentLateralOffset = 0f;

    private void LateUpdate()
    {
        if (player == null || vehicle == null) return;

        // 1️⃣ Position de base derrière la voiture
        Vector3 desiredPosition = player.TransformPoint(offset);

        // 2️⃣ Décalage latéral selon le braquage (smoothé)
        float targetLateralOffset = -vehicle.Steering * lateralOffsetMultiplier;
        float lerpFactor = 1f - Mathf.Exp(-lateralSmoothSpeed * Time.deltaTime);
        currentLateralOffset = Mathf.Lerp(currentLateralOffset, targetLateralOffset, lerpFactor);

        Vector3 lateralVector = player.right * currentLateralOffset;

        // 3️⃣ Appliquer le décalage latéral sans lisser le forward ou la hauteur
        transform.position = desiredPosition + lateralVector;

        // 4️⃣ Rotation : pitch fixe + suivre la rotation Y du joueur
        float yaw = player.eulerAngles.y;
        transform.rotation = Quaternion.Euler(pitchAngle, yaw, 0f);
    }
}
