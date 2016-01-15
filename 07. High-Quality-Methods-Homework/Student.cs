using System.Globalization;

namespace Methods
{
    using System;

    class Student
    {
        private string firstName;
        private string lastName;
        private string otherInfo;

        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name cannot be null or whitespace.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name cannot be null or whitespace.");
                }

                this.lastName = value;
            }
        }

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }

            set
            {
                this.otherInfo = value;
            }
        }

        public bool IsOlderThan(Student student)
        {
            DateTime firstDate = new DateTime();
            DateTime secondDate = new DateTime();
            string format = "dd.mm.yyyy";
            string firstStudentDateString = this.OtherInfo.Substring(this.OtherInfo.Length - 10);
            string secondStudentDateString = student.OtherInfo.Substring(student.OtherInfo.Length - 10);

            if (!DateTime.TryParseExact(firstStudentDateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out firstDate) ||
                !DateTime.TryParseExact(secondStudentDateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out secondDate))
            {
                throw new FormatException("Invalid date format.");
            }

            return firstDate < secondDate;

        }
    }
}
