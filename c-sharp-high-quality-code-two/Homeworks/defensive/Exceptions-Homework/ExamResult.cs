using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("The current student's grade cannot be a negative number!");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("The lowest grade cannot be a negative number!");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("The highest grade cannot be less than the lowest grade!");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentNullException("The comments variable cannot be null or an empty string!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
