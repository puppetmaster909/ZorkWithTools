using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zork.Common;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string GameFileAssetName = "Zork";

    [SerializeField]
    private UnityOutputService Output;

    [SerializeField]
    private UnityInputService InputService;

    private Game Game { get; set; }

    private void Awake()
    {
        TextAsset gameFileAsset = Resources.Load<TextAsset>(GameFileAssetName);
        Game = Game.LoadFromJson(gameFileAsset.text, Output, InputService);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Game.Output.WriteLine("Welcome To Zork!");
        //Game.CommandManager.PerformCommand(Game, "LOOK");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (string.IsNullOrWhiteSpace(InputService.InputField.text) == false)
            {
                Game.Output.WriteLine(InputService.InputField.text);
                InputService.ProcessInput();
            }
            InputService.InputField.text = string.Empty;
            InputService.InputField.Select();
            InputService.InputField.ActivateInputField();
        } 
    }
}
