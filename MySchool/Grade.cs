namespace MySchool
{
    class Grade
    {
        private int gradeId;
        public int GradeId {
            get { return gradeId; }
            set { this.gradeId = value; }
        }

        private string gradeName;
        public string GradeName
        {
            get { return gradeName; }
            set { this.gradeName = value; }
        }

        public Grade(string gradeName)
        {
            this.gradeName = gradeName;
        }

    }
}
