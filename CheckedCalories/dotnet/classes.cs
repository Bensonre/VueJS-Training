using System;
using System.Collections.Generic;
/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace Classes
{
    namespace reviews
    {

    public class singleReview
    {
        public string Name { get; set; }

        public int Rating { get; set; }

        public string Review { get; set; }
    }
    }
    namespace reviewList
    {
    using reviews;
    public class FoodReview
    {
       public string Id { get; set; }

        public List<singleReview> reviews { get; set;}
   
    }
    }
}
