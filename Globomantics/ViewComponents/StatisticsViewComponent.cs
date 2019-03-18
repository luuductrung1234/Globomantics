using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.ViewComponents
{
    public class StatisticsViewComponent : ViewComponent
    {
        private readonly IConferenceService _service;        

        public StatisticsViewComponent(IConferenceService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string statsCaption)
        {
            ViewBag.Caption = statsCaption;
            return View(await _service.GetStatistics());
        }
    }
}
