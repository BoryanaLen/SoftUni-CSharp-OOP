using P01.Stream_Progress.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class Video : IStreamable
    {
        public Video(string space, int length, int bytesSent)
        {
            this.Space = space;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }
        public int BytesSent { get; set; }

        public string Space { get; set; }
    }
}
