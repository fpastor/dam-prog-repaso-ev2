namespace repasoProgEV2.Classroom
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

        public void RemoveStudentsWithName(string name)
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
}
