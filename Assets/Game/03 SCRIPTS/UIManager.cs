using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Text")]
    [SerializeField] Text _score_Text;
    [SerializeField] Text _scoreLose_Text;
    [SerializeField] Text _highScore_Text;

    [SerializeField] GameObject _loseObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreDisPlayLose(int score, int highScore)
    {
        _loseObj.SetActive(true);
        _scoreLose_Text.text = $"Score: {score}";
        _highScore_Text.text = $"High Score: {highScore}";
    }

    public void UpdateScore(int score)
    {
        this._score_Text.text = $"Score: {score}";
    }
}
