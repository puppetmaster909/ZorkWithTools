using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zork.Common;
using TMPro;

public class UnityOutputService : MonoBehaviour, IOutputService
{
    [SerializeField]
    private TextMeshProUGUI TextLinePrefab;

    [SerializeField]
    private Transform OutputTextContainer;

    private List<GameObject> TextLines;

    [SerializeField]
    private int MaxTextlines = 60;

    public UnityOutputService()
    {
        TextLines = new List<GameObject>();
    }

    public void Clear()
    {
        throw new System.NotImplementedException();
    }

    public void Write(string value)
    {
        throw new System.NotImplementedException();
    }

    public void Write(object value)
    {
        throw new System.NotImplementedException();
    }

    public void WriteLine(string value)
    {
        if (TextLines.Count >= MaxTextlines)
        {
            Destroy(TextLines[0]);
            TextLines.RemoveAt(0);
        }

        var textLine = Instantiate(TextLinePrefab);
        textLine.transform.SetParent(OutputTextContainer, false);
        textLine.text = value;
        TextLines.Add(textLine.gameObject);
    }

    public void WriteLine(object value)
    {
        //OutputText.text = value.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
