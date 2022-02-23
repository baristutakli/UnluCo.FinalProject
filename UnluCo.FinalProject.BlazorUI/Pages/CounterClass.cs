using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace UnluCo.FinalProject.BlazorUI.Pages
{
    public class CounterClass:ComponentBase
    {
        public int CurrentCount { get; set; }

        public void IncrementCount()
        {
            CurrentCount += 5;
        }
    }
}
