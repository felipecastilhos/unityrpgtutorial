using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFade : MonoBehaviour
{
    [SerializeField] Animator textAnimator;
    [SerializeField] Text text;

    // Use this for initialization
    void Start() {
        textAnimator = GetComponent<Animator>();
        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator ShowText(string textToShow)
    {
        textAnimator.Play("TextIn");
        text.text = textToShow; 
        yield return new WaitForSeconds(1);
        textAnimator.Play("TextOut");
    }
}
