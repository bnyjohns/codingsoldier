using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CodingSoldier.Models
{
    public interface IBaseViewModel
    {
        IEnumerable<SelectListItem> Categories { get; set; }
    }
}