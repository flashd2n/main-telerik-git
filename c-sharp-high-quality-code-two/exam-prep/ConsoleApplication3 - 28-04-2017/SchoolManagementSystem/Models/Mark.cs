using SchoolManagementSystem.Interfaces;

namespace SchoolManagementSystem
{
    public class Mark : IMark
    {
        private int markValue;
        private Subject markSubject;

        public Mark(Subject markSubject, int markValue)
        {
            this.MarkSubject = markSubject;
            this.MarkValue = markValue;
        }

        public int MarkValue
        {
            get
            {
                return this.markValue;
            }

            private set
            {
                this.markValue = value;
            }
        }

        public Subject MarkSubject
        {
            get
            {
                return this.markSubject;
            }

            private set
            {
                this.markSubject = value;
            }
        }


    }
}
