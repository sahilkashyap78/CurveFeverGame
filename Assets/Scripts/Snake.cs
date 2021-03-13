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
    // Update is called once per frame
    void Update()
    {
        m_Horizontal = Input.GetAxisRaw(InputAxis);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * m_Speed * Time.fixedDeltaTime, Space.Self);
        transform.Rotate(Vector3.forward * m_Horizontal* m_RotationSpeed * Time.fixedDeltaTime);
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
        
}
