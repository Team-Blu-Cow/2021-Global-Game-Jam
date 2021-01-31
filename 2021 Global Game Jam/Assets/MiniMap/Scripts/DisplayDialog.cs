using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayDialog : MonoBehaviour
{
    public MasterInput controls;

    TextMeshProUGUI tmp;
    Queue<string> sentances;
    Queue<float> delays;

    // Start is called before the first frame update
    void Start()
    {
        sentances = new Queue<string>();
        delays = new Queue<float>();
        tmp = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Awake()
    {
        controls = new MasterInput();
        controls.PlayerControls.Dialogue.performed += ctx => DisplayNextSentace();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void StartDialog(string[] customDialog, float[] textDelay)
    {
        sentances.Clear();

        LeanTween.move(gameObject, new Vector3(transform.position.x, -30,0), 1);

        foreach(string sentance in customDialog)
        {
            sentances.Enqueue(sentance);
        }
        
        foreach(float delay in textDelay)
        {
            delays.Enqueue(delay);
        }

        DisplayNextSentace();
    }

    public void DisplayNextSentace()
    {
        if (sentances.Count == 0)
        {
            EndDialog();
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(TypeSentance(sentances.Dequeue(), delays.Dequeue()));
        }
    }

    void EndDialog()
    {
        LeanTween.move(gameObject, new Vector3(transform.position.x, -490, 0), 1);
    }

    public IEnumerator TypeSentance(string sentance, float delay)
    {
        tmp.text = "";
        foreach(char letter in sentance.ToCharArray())
        {
            tmp.text += letter;
            yield return new WaitForSeconds(delay);
        }     
    }
}
