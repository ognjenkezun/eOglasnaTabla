using System;
using System.Collections.Generic;

namespace ElektronskaOglasnaTabla.Domain.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Announcements = new HashSet<Announcements>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Announcements> Announcements { get; set; }
    }
}
