using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 3f;
    [SerializeField]
    private float m_RotationSpeed = 200f;
    private float m_Horizontal = 0f;
    public string InputAxis = "Horizontal";
    [SerializeField]
    GameManager m_GameManager;
    
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * m_Speed * Time.fixedDeltaTime, Space.Self);
        transform.Rotate(Vector3.forward * m_Horizontal* m_RotationSpeed * Time.fixedDeltaTime);
        m_Horizontal = 0f;
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.tag == "kills")
        {
            m_Speed = 0f;
            m_RotationSpeed = 0f;
            m_GameManager.EndGame();
        }    
        
    }

    public void LeftButtton()
    {
        m_Horizontal = -1f;
    }

    public void RightButtton()
    {
        m_Horizontal = 1f;
    }

}
