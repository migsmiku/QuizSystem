namespace OnlineQuiz.Models.Enum
{
    using System.ComponentModel;

    public enum QuizCategory
    {
        [Description(".Net")]
        DotNet=1,
        [Description("C#")]
        CSharp=2,
        [Description("Sql Server")]
        SqlServer=3
    }
}