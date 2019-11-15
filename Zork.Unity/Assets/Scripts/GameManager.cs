using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zork.Common;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string GameFileAssetName = "Zork";

    [SerializeField]
    private UnityOutputService Output;

    [SerializeField]
    private UnityInputService InputService;

    [SerializeField]
    private TextMeshProUGUI LocationNameText;

    [SerializeField]
    private TextMeshProUGUI ScoreText;

    [SerializeField]
    private TextMeshProUGUI MovesText;

    private Game Game { get; set; }

    private void Awake()
    {
        TextAsset gameFileAsset = Resources.Load<TextAsset>(GameFileAssetName);
        Game = Game.LoadFromJson(gameFileAsset.text, Output, InputService);
        Game.Player.LocationChanged += LocationChanged;
        Game.Player.ScoreChanged += ScoreChanged;
        Game.Player.MovesChanged += MovesChanged;
        Game.HasQuit += QuitGame;
    }

    private void LocationChanged(object sender, string e)
    {
        LocationNameText.text = Game.Player.Location.ToString();
    }

    private void MovesChanged(object sender, int e)
    {
        MovesText.text = $"Moves: {Game.Player.Moves}";
    }

    private void ScoreChanged(object sender, int e)
    {
        ScoreText.text = $"Score: {Game.Player.Score}";
    }

    private void QuitGame(object sender, bool e)
    {
        StartCoroutine(QuitTimer());
    }

    // Start is called before the first frame update
    void Start()
    {
        LocationNameText.text = Game.Player.Location.ToString();
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

    private IEnumerator QuitTimer()
    {
        Game.Output.WriteLine("Thank you for playing!");
        yield return new WaitForSeconds(3);
        Application.Quit();
        Debug.Log("Application has exited");
    }
}