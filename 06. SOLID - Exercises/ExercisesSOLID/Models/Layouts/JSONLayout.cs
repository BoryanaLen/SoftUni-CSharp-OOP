using ExercisesSOLID.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesSOLID.Models.Layouts
{
    public class JSONLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\"log\":[");
            sb.AppendLine("\t\"date\":\"{0}\",");
            sb.AppendLine("\t\"level\":\"{1}\",");
            sb.AppendLine("\t\"message\":\"{2}\"");
            sb.AppendLine("]");

            return sb.ToString().TrimEnd();
        }
    }
}
