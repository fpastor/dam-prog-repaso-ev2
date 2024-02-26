using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repasoProgEV2.Classroom
{
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
}
