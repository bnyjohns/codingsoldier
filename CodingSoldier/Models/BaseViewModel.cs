using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CodingSoldier.Models
{
    public abstract class BaseViewModel
    {
        public virtual IEnumerable<SelectListItem> Categories { get; set; }        
    }
}