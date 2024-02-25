
namespace repasoProgEV2
{
    public enum GenderType
    {
        MALE, FEMALE, OTHER
    }

    public enum SubjectType
    {
        MATHS, SCIENCE, HISTORY, LANGUAJE
    }

    public enum GradeRangeType
    {
        PLUS_9, FROM_7_TO_9, FROM_5_TO_7, FROM_3_TO_5, FROM_0_T0_3
    }

    public class Classroom
    {
        private List<Student> Students = new List<Student>();
        private string Name { get; set; } = string.Empty;

        public Classroom()
        {
        }

        public Classroom(List<Student> students)
        {
            var studentsClone = new List<Student>();
            foreach (Student student in students)
                studentsClone.Add(student.Clone());
        }

        public int GetStudentCount()
        {
            return Students.Count;
        }

        public Student? GetStudentAt(int index)
        {
            if (0 < index && index < Students.Count)
                return Students[index];
            return null;
        }

        public void RenoveStudentAt(int index)
        {
            if (0 <= index && index <= Students.Count)
                Students.RemoveAt(index);
        }

        public bool ContainsStudentWithName(string name)
        {
            foreach (Student student in Students)
            { 
                if (name == student.GetName())
                    return true;
            }
            return false;
        }

        public void RemoveStudentsWithName (string name)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (name == Students[i].GetName())
                {
                    Students.Remove(Students[i]);
                    i--;
                }
            }
        }
    }

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

    public class ReportCard
    {
        private List<SubjectGrade> Grades = new List<SubjectGrade>();

        public ReportCard()
        {
        }

        public ReportCard Clone()
        {
            ReportCard cloneReportCard = new ReportCard();
            foreach (SubjectGrade grade in Grades)
                cloneReportCard.Grades.Add(grade.Clone());
            return cloneReportCard;
        }

        public int GetGradesCount() 
        {
            return Grades.Count;
        }

        public SubjectGrade? GetGradesAt(int index)
        {
            if (0 < index && index < Grades.Count)
                return Grades[index];
            return null;
        }

        public double GetAverageGrade()
        {
            double sum = 0;
            foreach (var grade in Grades)
                sum = +grade.GetQualification();
            return sum / Grades.Count;
        }

        public SubjectGrade GetTopSubjectGrade()
        {
            SubjectGrade topGrade = Grades[0];
            int gradesCount = GetGradesCount();

            for (int i = 1; i < gradesCount; i++)
            {
                if (Grades[i].GetQualification() > topGrade.GetQualification())
                    topGrade = Grades[i];
            }
            return topGrade;
        }

        public SubjectGrade GetBottomSubjectGrade()
        {
            SubjectGrade bottomGrade = Grades[0];
            int gradesCount = GetGradesCount();

            for (int i = 1; i < gradesCount; i++)
            {
                if (Grades[i].GetQualification() < bottomGrade.GetQualification())
                    bottomGrade = Grades[i];
            }
            return bottomGrade;
        }

        public double GetTopQualification()
        {
            SubjectGrade bottomGrade = Grades[0];
            int gradesCount = GetGradesCount();

            for (int i = 1; i < gradesCount; i++)
            {
                if (Grades[i].GetQualification() > bottomGrade.GetQualification())
                    bottomGrade = Grades[i];
            }
            return bottomGrade.GetQualification();
        }

        public double GetBottomQualification()
        {
            SubjectGrade bottomGrade = Grades[0];
            int gradesCount = GetGradesCount();

            for (int i = 1; i < gradesCount; i++)
            {
                if (Grades[i].GetQualification() < bottomGrade.GetQualification())
                    bottomGrade = Grades[i];
            }
            return bottomGrade.GetQualification();
        }

        public class SubjectGrade
        {
            private SubjectType Subject { get; set; }
            private double Qualification { get; set; }
            
            public SubjectGrade Clone()
            {
                return new()
                {
                    Subject = Subject,
                    Qualification = Qualification
                };
            }

            public double GetQualification() => Qualification;
        }
    }

    public class Stadistics
    {
        public static double GetAverageIMC(Classroom classroom)
        {
            if (classroom == null)
                return -1;

            double sum = 0;
            int studentCount = classroom.GetStudentCount();

            for (int i = 0; i < studentCount; i++)
            {
                if (classroom.GetStudentAt(i) != null)
                    sum += classroom.GetStudentAt(i).GetIMC();
            }
            return sum / studentCount;
        }

        public static Student? GetBestStudent(Classroom classroom)
        {
            if (classroom == null || classroom.GetStudentCount() == 0  || classroom.GetStudentAt(0) == null)
                return null;

            Student bestStudent = classroom.GetStudentAt(0);

            int studentCount = classroom.GetStudentCount();
            
            for (int i = 1; i < studentCount; i++)
            {
                if (bestStudent.GetReportCard().GetTopQualification() < classroom.GetStudentAt(i).GetReportCard().GetTopQualification())
                    bestStudent = classroom.GetStudentAt(i);
            }
            return bestStudent;
        }

        public static Student? GetYoungestStudent(Classroom classroom)
        {
            if(classroom != null || classroom.GetStudentCount() != 0 || classroom.GetStudentAt(0) != null)
            {
                int studentCount = classroom.GetStudentCount();
                Student youngest = classroom.GetStudentAt(0);

                for (int i = 1; i < studentCount; i++)
                {
                    if (youngest.GetAge() < classroom.GetStudentAt(i).GetAge())
                        youngest = classroom.GetStudentAt(i);
                }
                return youngest;
            }
            return null;
        }

        public static List<Student> GetSortedStudentsOfSubject(SubjectType subject, Classroom classroom)
        {
            List<Student> result = new();

            /* - PENDIENTE DESARROLLAR - */

            return result;
        }

        public static List<Student> GetStudentsWithGender(GenderType gender, Classroom classroom)
        {
            List<Student> result = new();

            /* - PENDIENTE DESARROLLAR - */

            return result;
        }

        public static Dictionary<GradeRangeType, int> GetStadistics(Classroom classroom)
        {
            Dictionary<GradeRangeType, int> result = new();

            /* - PENDIENTE DESARROLLAR - */

            return result;
        }

    }
}
