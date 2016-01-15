using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.CheckGradesRange(minGrade, maxGrade);
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }


    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Grade cannot be negative.");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Minimal grade cannot be negative.");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Maximal grade cannot be negative.");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get { return this.comments; }

        private set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Comments cannot be null or empty.");
            }

            this.comments = value;
        }
    }

    private void CheckGradesRange(int minGrade, int maxGrade)
    {
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Minimal grade value cannot be greater than the maximal grade value.");
        }
    }
}

