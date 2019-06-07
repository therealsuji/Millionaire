using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class GameManager : MonoBehaviour
{


    static int noQuestions = 15;
    Question[] questionArray = new Question[noQuestions];
    static List<Question> unansweredQuestion;
    Question curentQuestion;

    static Animator confirmPanelAnim;
    static Animator prizeAnim;

    static TextMeshProUGUI questionText;

    static Button answer1Btn;
    static Button answer2Btn;
    static Button answer3Btn;
    static Button answer4Btn;
    static Button confirmBtn;

    static TextMeshProUGUI answer1Text;
    static TextMeshProUGUI answer2Text;
    static TextMeshProUGUI answer3Text;
    static TextMeshProUGUI answer4Text;

    static GameObject confirmPanel;

    static bool gameOver = false;

    int timeForNextQuestion = 1;
    int temporaryAnswer;
    int correctAns = 0;

    void Awake()
    {

        confirmPanel = GameObject.Find("confirmationPanel");
        questionText = GameObject.Find("question").GetComponent<TextMeshProUGUI>();
        answer1Btn = GameObject.Find("answer1Btn").GetComponent<Button>();
        answer2Btn = GameObject.Find("answer2Btn").GetComponent<Button>();
        answer3Btn = GameObject.Find("answer3Btn").GetComponent<Button>();
        answer4Btn = GameObject.Find("answer4Btn").GetComponent<Button>();
        confirmBtn = GameObject.Find("yes").GetComponent<Button>();

        answer1Text = GameObject.Find("answer1").GetComponent<TextMeshProUGUI>();
        answer2Text = GameObject.Find("answer2").GetComponent<TextMeshProUGUI>();
        answer3Text = GameObject.Find("answer3").GetComponent<TextMeshProUGUI>();
        answer4Text = GameObject.Find("answer4").GetComponent<TextMeshProUGUI>();
        confirmPanelAnim = confirmPanel.GetComponent<Animator>();
        prizeAnim = GameObject.Find("Image").GetComponent<Animator>();
    }

    void Start()
    {

        if (unansweredQuestion == null)
        {
            Debug.Log("init");
            initializeQuestionArray();
            unansweredQuestion = questionArray.ToList<Question>();
        }



    }

    void updatePrize()
    {

        correctAns = noQuestions - unansweredQuestion.Count;
        print(correctAns);
        if (correctAns == 1)
        {
            prizeAnim.SetBool('1', true);

        }
    }
    void Update()
    {
        if (unansweredQuestion.Count == 0)
        {
            gameOver = true;
            Debug.Log("gameOver");
        }
        if (!gameOver)
        {
            setCurrentQuestion();
            setQuestionText();
            setAnswersText();
            listenAnswer();
            confirmAnswer();
            updatePrize();
        }
    }

    public void confirmPanelEnableAnim()
    {
        confirmPanelAnim.SetBool("enabled", true);
    }
    public void confirmPanelDisableAnim()
    {
        confirmPanelAnim.SetBool("enabled", false);
    }


    void getClickedBtn(int tempAnswer)
    {
        temporaryAnswer = tempAnswer;
    }




    void confirmAnswer()
    {
        confirmBtn.onClick.AddListener(() => checkAnswer(temporaryAnswer));

    }


    void initializeQuestionArray()
    {
        questionArray[0] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[1] = new Question("what is the lowest place on mars", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[2] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[3] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[4] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[5] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[6] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[7] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[8] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[9] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[10] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[11] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[12] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[13] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");
        questionArray[14] = new Question("what is the higest place on earth", "Mount Everest", "Mauna Kea", " Mount Chimborazo", "Kangchenjunga", "Mount Everest");


    }
    void removeListner()
    {
        confirmBtn.onClick.RemoveAllListeners();
        answer1Btn.onClick.RemoveAllListeners();
        answer2Btn.onClick.RemoveAllListeners();
        answer3Btn.onClick.RemoveAllListeners();
        answer4Btn.onClick.RemoveAllListeners();
    }
    void listenAnswer()
    {
        answer1Btn.onClick.AddListener(() => getClickedBtn(1));
        answer2Btn.onClick.AddListener(() => getClickedBtn(2));
        answer3Btn.onClick.AddListener(() => getClickedBtn(3));
        answer4Btn.onClick.AddListener(() => getClickedBtn(4));



    }

    void setCurrentQuestion()
    {
        curentQuestion = unansweredQuestion[0];
    }

    IEnumerator moveToNextQuestion()
    {
        removeListner();
        unansweredQuestion.Remove(curentQuestion);
        yield return new WaitForSeconds(timeForNextQuestion);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void checkAnswer(int btn)
    {
        switch (btn)
        {
            case 1:
                if (answer1Text.text == curentQuestion.getCorrectAnswer())
                {
                    Debug.Log("Corect");

                }
                else
                {
                    Debug.Log("incorrect");

                }
                StartCoroutine(moveToNextQuestion());
                break;
            case 2:
                if (answer2Text.text == curentQuestion.getCorrectAnswer())
                {
                    Debug.Log("Corect");


                }
                else
                {
                    Debug.Log("incorrect");

                }
                StartCoroutine(moveToNextQuestion());

                break;
            case 3:
                if (answer3Text.text == curentQuestion.getCorrectAnswer())
                {
                    Debug.Log("Corect");



                }
                else
                {
                    Debug.Log("incorrect");
                }
                StartCoroutine(moveToNextQuestion());

                break;
            case 4:
                if (answer4Text.text == curentQuestion.getCorrectAnswer())
                {
                    Debug.Log("Corect");




                }
                else
                {
                    Debug.Log("incorrect");

                }
                StartCoroutine(moveToNextQuestion());

                break;

        }

    }

    void setQuestionText()
    {
        questionText.text = curentQuestion.getQuestion();
    }
    void setAnswersText()
    {
        answer1Text.text = curentQuestion.getAnswer1();
        answer2Text.text = curentQuestion.getAnswer2();
        answer3Text.text = curentQuestion.getAnswer3();
        answer4Text.text = curentQuestion.getAnswer4();


    }

}

