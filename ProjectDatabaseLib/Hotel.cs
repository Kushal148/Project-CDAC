//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectDatabaseLib
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hotel
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string HotelName { get; set; }
        public int Price { get; set; }
        public int Hoteltype { get; set; }
        public string hotelImage { get; set; }
    
        public virtual Location Location { get; set; }
    }
}
