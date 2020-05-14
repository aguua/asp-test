using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationxD.Models
{
    public class BookSeriesViewModel
    {
        public List<Book> Books { get; set; }
        public SelectList BookSeries { get; set; }
        public string Series { get; set; }
        public string SearchString { get; set; }
    }
}
