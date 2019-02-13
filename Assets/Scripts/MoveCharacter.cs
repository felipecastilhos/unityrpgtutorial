using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {
    private float velocity;
    private Vector2 direction;
    public Animator animator;
    private Rigidbody2D heroRb;

    private Vector2 heroDirection;

    private SpriteRenderer heroRender;
    private bool enableDamageColor;
    [SerializeField] private bool criticalDamage;


    // Start is called before the first frame update
    void Start() {
        velocity = 4;
        direction = Vector2.zero;
        heroRb = GetComponent<Rigidbody2D>();
        heroRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        inputCharacter();
        if (direction.x != 0.0f || direction.y != 0.0f) {
            Animate(direction);
        }
        else {
            animator.SetLayerWeight(1, 0);
        }

        if(enableDamageColor) {
            PingPongColor(8); 
        }

        if(criticalDamage){
            PingPongColor(1);
        }
    }

    private void FixedUpdate() {
        heroRb.MovePosition(heroRb.position + direction * velocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Death")) {
            StartCoroutine(KnockBack(2f, 50, heroDirection));
            DamageColor();
        }
    }


    void inputCharacter() {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            direction += Vector2.up;
            heroDirection = direction;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            direction += Vector2.down;
            heroDirection = direction;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            direction += Vector2.left;
            heroDirection = direction;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            direction += Vector2.right;
            heroDirection = direction;
        }

    }

    private void PingPongColor(int value) {
        heroRender.color = Color.Lerp(Color.white, Color.magenta, Mathf.PingPong(value * Time.time, .5f));
    }

    void DamageColor() {
        enableDamageColor = true;
        StartCoroutine(EnableDamageColor());
    }

    void Animate(Vector2 dir) {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("x", dir.x);
        animator.SetFloat("y", dir.y);
    }

    public IEnumerator KnockBack(float duration, float power, Vector2 direction) {
        float time = 0f;
        while(duration > time) {
            time += Time.deltaTime;
            Vector2 force = new Vector2(direction.x * -power, direction.y * -power);
            heroRb.AddForce(force, ForceMode2D.Force);
        }

        yield return 0;
    }

    public IEnumerator EnableDamageColor() { 
        yield return new WaitForSeconds(0.5f);
        enableDamageColor = false;
        heroRender.color = new Color(1f, 1f, 1f, 1f);

    }
}
