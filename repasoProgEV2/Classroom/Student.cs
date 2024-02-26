
namespace repasoProgEV2.Classroom
{
    public class Student
    {
        private string Name { get; set; } = string.Empty;
        private int Age { get; set; }
        private GenderType Gender { get; set; }
        private double Height { get; set; }
        private double Weight { get; set; }
        private ReportCard ReportCard { get; set; } = new ReportCard();

        public Student() { }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string GetName() => Name;

        public int GetAge() => Age;

        public ReportCard GetReportCard() => ReportCard;

        public Student Clone() => new()
        {
            Name = Name,
            Age = Age,
            Gender = Gender,
            Height = Height,
            Weight = Weight,
            ReportCard = ReportCard.Clone()
        };

        public double GetIMC()
        {
            return Weight / Math.Pow(Height, 2);
        }

        public double GetAverage()
        {
            double sumGrades = 0;
            int gradesCount = ReportCard.GetGradesCount();
            for (int i = 0; i < gradesCount; i++)
            {
                if (ReportCard.GetGradesAt(i) != null)
                    sumGrades += ReportCard.GetGradesAt(i).GetQualification();
            }
            return sumGrades / gradesCount;
        }

        public bool Over18() => Age >= 18;

    }
}
