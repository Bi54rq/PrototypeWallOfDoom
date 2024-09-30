using UnityEngine;

public class CameraFade : MonoBehaviour
{
    public float speedScale = 1f;
    public Color fadeColor = Color.black;
    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));
    
    private float alpha = 0f; 
    private Texture2D texture;
    private int direction = 0; // 1 = fade out, -1 = fade in
    private float time = 0f;
    private System.Action onComplete;

    private void Start()
    {
        alpha = 0f; // Start fully transparent
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }

    private void Update()
    {
        if (direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = Curve.Evaluate(time);
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();
            if (alpha <= 0f || alpha >= 1f)
            {
                direction = 0; // Stop fading
                if (alpha >= 1f && onComplete != null)
                {
                    onComplete.Invoke(); // Call the completion action if fading out
                    onComplete = null; // Clear the action
                }
            }
        }
    }

    public void OnGUI()
    {
        if (alpha > 0f) GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
    }

    public void FadeToBlack(System.Action onComplete)
    {
        this.onComplete = onComplete; // Set the action to call when fading is done
        direction = 1; // Start fading out
        time = 0f; // Reset time
    }

    public void FadeIn()
    {
        direction = -1; // Start fading in
        time = 1f; // Start from fully faded out
    }
}
