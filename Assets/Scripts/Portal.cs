using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Portal : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private Tilemap targeTilemap;
    [SerializeField] private Image fadeImage;
    [SerializeField] private Text animatedText;

    private void Awake() {
        fadeImage.enabled = false;

    }

    IEnumerator OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("hero")){
            PlayerMovementManager moveCharacter = collision.GetComponent<PlayerMovementManager>();
            Animator characterAnimator = collision.GetComponent<Animator>();
            startFadeAnimation(FadeState.IN);
            CanWalk(moveCharacter, characterAnimator, false);
            yield return new WaitForSeconds(1);
            collision.transform.position = target.GetChild(0).transform.position;
            ConfigureCameraByTileMap();
            CanWalk(moveCharacter, characterAnimator, true);
            startFadeAnimation(FadeState.OUT);
            StartCoroutine(animatedText.GetComponent<TextFade>().ShowText(targeTilemap.tag));

        }
        yield return 0;
    }

    private void ConfigureCameraByTileMap(){
        TargetCamera.instance.tileMap = targeTilemap;
        TargetCamera.instance.StartMap();
    }

    private void startFadeAnimation(FadeState fadeState) {
        Animator anim = fadeImage.GetComponent<Animator>();

        if(fadeState == FadeState.IN) {
            fadeImage.enabled = true;
            anim.Play("FadeInAnimation");
        }
        else if(fadeState == FadeState.OUT)
        {
            anim.Play("FadeOutAnimation");
            fadeImage.enabled = false;

        }
    }

   private void CanWalk(PlayerMovementManager moveCharacter, Animator animator, bool canWalk) {
        moveCharacter.enabled = canWalk;
        animator.enabled = canWalk;
    }


    enum FadeState
    {
        IN,
        OUT
    }
}
