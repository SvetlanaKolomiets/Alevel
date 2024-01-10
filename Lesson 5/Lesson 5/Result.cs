using System;

namespace Lesson_5
{
    public class Result
    {
        private bool _status;
        private string _error;

        public Result()
        {
            this._status = true;
        }

        public bool Status
        {
            get { return this._status; }

            set { this._status = value; }
        }

        public string Error
        {
            get { return this._error; }

            set { this._error = value; }
        }
    }
}