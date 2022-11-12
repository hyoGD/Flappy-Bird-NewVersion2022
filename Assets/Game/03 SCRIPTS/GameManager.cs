using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Transform _posTube;
    [SerializeField] Tube _tube;

    [SerializeField] float delayTime;
    [SerializeField] int _score;
    private bool isLose;
    public bool IsLose { get => isLose; set => isLose = value; }
    private bool isUI;
    public bool IsUI { get => isUI; set => isUI = value; }
    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt("HIGHSCORE", 0);
        }
        set
        {
            PlayerPrefs.SetInt("HIGHSCORE", value);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        this.IsUI = true;
        Time.timeScale = 0;
        Debug.Log(HighScore);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        this.IsUI = false;
        SpwamTube();
    }

    private void SpwamTube()
    {
        StartCoroutine(StartSpwamTube());
    }

    IEnumerator StartSpwamTube()
    {
        while (!IsLose)
        {
            yield return new WaitForSeconds(delayTime);
            Tube tube = Instantiate(_tube, _posTube.position, Quaternion.identity);
            tube.SetPositon();
        }
        yield return new WaitForSeconds(0.1f);
    }

    public void AddScore()
    {
        _score++;
        UIManager.Instant.UpdateScore(this._score);
    }

    public void Lose()
    {
        this.IsLose = true;
        if (_score > HighScore)
        {
            HighScore = _score;
        }
        UIManager.Instant.UpdateScoreDisPlayLose(this._score, this.HighScore);
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
