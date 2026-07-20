using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public static class ManagerQuestions {
    private class Question {
        private string question;
        private string correct;
        private string[] incorrects = new string[3];
        public Question(string question,
                        string correct,
                        string incorrects1,
                        string incorrects2,
                        string incorrects3) {
            this.question = question;
            this.correct = correct;
            this.incorrects[0] = incorrects1;
            this.incorrects[1] = incorrects2;
            this.incorrects[2] = incorrects3;
        }

        public bool IsCorrect(string res) {
            return res == correct;
        }
        public string ToString() {
            return question + ";;" + correct + ";;" + incorrects[0] + ";;" + incorrects[1] + ";;" + incorrects[2];
        }
    }
    private static Question[] listQuestions = {
        new Question("Qual é o numero 1",
                    "1",
                    "2",
                    "3",
                    "4"),
        new Question("Qual é o numero 2",
                    "2",
                    "1",
                    "3",
                    "4"),
        new Question("Qual é o numero 3",
                    "3",
                    "1",
                    "2",
                    "4"),
        new Question("Qual é o numero 4",
                    "4",
                    "2",
                    "3",
                    "1")
    };
    private static int questionsQuant = listQuestions.Length;
    private static int[] orderQuestion = new int[questionsQuant];
    private static int numQuestion = 0;
    private static Question activeQuest = null;
    
    public static string SortRandomQuest() {
        if(numQuestion == questionsQuant) numQuestion = 0;
        if(numQuestion == 0) createOrderQuestion();
        Question quest = listQuestions[orderQuestion[numQuestion]];
        numQuestion++;
        activeQuest = quest;
        return quest.ToString();
    }
    public static bool CheckeedIfCorrect(string res) {
        bool isCorrect = activeQuest.IsCorrect(res);
        return isCorrect;
    }

    private static void createOrderQuestion() {
        Random rand = new Random();
        List<int> numbers = new List<int>();
        for(int i = 0; i < questionsQuant; i++) numbers.Add(i);
        for(int i = 0; i < questionsQuant; i++) {
            int indexNumber = rand.Next(0, numbers.Count);
            orderQuestion[i] = numbers[indexNumber];
            numbers.RemoveAt(indexNumber);
        }
    }
}