using System.Collections;
using System.Collections.Generic;

public class Question
{
    string question;
    string answer1;
    string answer2;
    string answer3;
    string answer4;
    string correctAnswer;

    public Question(string question, string answer1, string answer2, string answer3, string answer4, string correctAnswer)
    {
        this.question = question;
        this.answer1 = answer1;
        this.answer2 = answer2;
        this.answer3 = answer3;
        this.answer4 = answer4;
        this.correctAnswer = correctAnswer;

    }
    public string getQuestion() { return question; }
    public string getAnswer1() { return answer1; }
    public string getAnswer2() { return answer2; }
    public string getAnswer3() { return answer3; }
    public string getAnswer4() { return answer4; }
    public string getCorrectAnswer() { return correctAnswer; }

}
