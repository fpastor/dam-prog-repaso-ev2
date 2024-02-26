using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repasoProgEV2.Classroom
{
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
            if (classroom == null || classroom.GetStudentCount() == 0 || classroom.GetStudentAt(0) == null)
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
            if (classroom != null || classroom.GetStudentCount() != 0 || classroom.GetStudentAt(0) != null)
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
