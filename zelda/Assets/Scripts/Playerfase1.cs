using UnityEngine;

public class Playerfase1 : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float moveSpeed = 5f;
    public float acceleration = 10f;

    [Header("Configurações de Esquiva")]
    public float dodgeSpeed = 15f;       // Velocidade durante a esquiva
    public float dodgeDuration = 0.3f;   // Tempo de duração da esquiva
    public float dodgeCooldown = 1f;     // Tempo de espera entre esquivas
    public KeyCode dodgeKey = KeyCode.LeftShift; // Tecla para esquiva

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isDodging = false;
    private float dodgeEndTime;
    private float nextDodgeTime;
    private Vector2 dodgeDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura input de movimento (WASD/setas)
        moveInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        // Ativa esquiva se:
        // 1) Tecla pressionada
        // 2) Não está já esquivando
        // 3) Cooldown acabou
        // 4) Está se movendo
        if (Input.GetKeyDown(dodgeKey)
            && !isDodging
            && Time.time >= nextDodgeTime
            && moveInput != Vector2.zero)
        {
            StartDodge();
        }
    }

    void FixedUpdate()
    {
        if (isDodging)
        {
            // Movimento durante esquiva (direção fixa)
            rb.velocity = dodgeDirection * dodgeSpeed;

            // Verifica se a esquiva terminou
            if (Time.time >= dodgeEndTime)
            {
                isDodging = false;
            }
        }
        else
        {
            // Movimento normal com aceleração suave
            Vector2 targetVelocity = moveInput * moveSpeed;
            rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, acceleration * Time.fixedDeltaTime);
        }
    }

    void StartDodge()
    {
        isDodging = true;
        dodgeDirection = moveInput; // Guarda a direção inicial
        dodgeEndTime = Time.time + dodgeDuration;
        nextDodgeTime = Time.time + dodgeDuration + dodgeCooldown;

        // Efeito visual opcional (pode remover)
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.7f); // Transparência
    }

    void EndDodge()
    {
        // Restaura efeitos visuais (se usados)
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    // Método para verificar se está esquivando (útil para outros scripts)
    public bool IsDodging()
    {
        return isDodging;
    }
}
