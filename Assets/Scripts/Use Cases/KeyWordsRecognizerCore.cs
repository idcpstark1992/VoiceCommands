using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;
public class KeyWordsRecognizerCore : MonoBehaviour
{
    
    public TMPro.TextMeshProUGUI prints;
    private KeywordRecognizer Recognizer;

    private void Start()
    {
        Recognizer = new KeywordRecognizer(Services.Instance.GetService<IEvents>().GetEventsKeys().ToArray());
        Recognizer.OnPhraseRecognized += OnRecognitionWord;
        Recognizer.Start();
    }
    private void OnDisable()
    {
        Recognizer.OnPhraseRecognized -= OnRecognitionWord;
    }

    private void OnRecognitionWord(PhraseRecognizedEventArgs _args)
    {

        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", _args.text, _args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", _args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", _args.phraseDuration.TotalSeconds, Environment.NewLine);
        prints.text = builder.ToString();

        if(!SharedStates.isGameOver)
            Services.Instance.GetService<IEvents>().TriggerEvent(_args.text);


        Debug.Log(_args.text);
    }
}
