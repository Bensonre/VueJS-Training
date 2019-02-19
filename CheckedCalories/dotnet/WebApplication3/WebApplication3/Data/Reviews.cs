using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Data
{
    public class Reviews
    {
        public int Id { get; set; }

        public int FoodId { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public int Rating { get; set; }
    }
}
