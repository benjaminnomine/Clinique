using System;
using System.Collections.Generic;

namespace Clinique.Domain.Services.API.Models
{
    public class APITimeline
    {
        public Dictionary<string, int> Cases { get;set;}
        public Dictionary<string, int> Deaths { get;set;}
    }
}