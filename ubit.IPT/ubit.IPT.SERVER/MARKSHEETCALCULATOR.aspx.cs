using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ubit.IPT.SERVER.model;

namespace ubit.IPT.SERVER
{
    public partial class MARKSHEETCALCULATOR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod (ResponseFormat = ResponseFormat.Json,UseHttpGet =true)]
        public static string GetMarksSheet()
        {
            string request = HttpContext.Current.Request.Params["request"];


            marksinfo[] marksinfo = JsonConvert.DeserializeObject<marksinfo[]>(request);

            int totalSubject = 0;
            int marksSecure = 0;



            int minMarks = marksinfo[0].subjectMarksObtained;

            string minMarksSubject = marksinfo[0].subjectName;

            int maxMarks = marksinfo[0].subjectMarksObtained;

            string maxMarksSubject = marksinfo[0].subjectName;

            for (int i=0; i < marksinfo.Length; i++) {

                marksinfo currentInfo = marksinfo[i];

                marksSecure += currentInfo.subjectMarksObtained ;
                totalSubject += 100;

                if(marksinfo[i].subjectMarksObtained < minMarks)
                {
                    minMarks = currentInfo.subjectMarksObtained;
                    minMarksSubject = currentInfo.subjectName;
                }

                if(currentInfo.subjectMarksObtained > maxMarks)
                {
                    maxMarks = currentInfo.subjectMarksObtained;
                    maxMarksSubject = currentInfo.subjectName;
                }


            }



            float average =   marksSecure * 100 / totalSubject;
            marksInfoResult result = new marksInfoResult();
            result.maxMarks = maxMarks;
            result.maxMarksSubject = maxMarksSubject;

            result.minMarks = minMarks;
            result.minMarksSubject = minMarksSubject;

            result.average = average;

            string resultStr = JsonConvert.SerializeObject(result);
            return resultStr;


        }




    }
}