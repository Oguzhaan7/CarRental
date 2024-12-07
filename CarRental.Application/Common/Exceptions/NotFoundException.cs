using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public string Title { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }
        public NotFoundException() : base()
        {
        }
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
