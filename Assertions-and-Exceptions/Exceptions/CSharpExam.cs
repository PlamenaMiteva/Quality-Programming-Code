using System;

public class CSharpExam : Exam
{
    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Exam score cannot be negative.");
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.Score > 100)
        {
            throw new ArgumentOutOfRangeException("Exam score cannot be greater than 100.");
        }

        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
