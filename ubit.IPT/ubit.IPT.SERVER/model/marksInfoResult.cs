using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ubit.IPT.SERVER.model
{
    public class marksInfoResult
    {
        public int minMarks { get; set; }
        public string minMarksSubject  { get; set; }
    public int maxMarks { get; set; }
    public string maxMarksSubject { get; set; }

        public float average { get; set; }

    }
}