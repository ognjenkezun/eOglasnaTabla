using System;
using System.Collections.Generic;

namespace ElektronskaOglasnaTabla.Domain.Models
{
    public partial class Announcements
    {
        public int AnnouncementId { get; set; }
        public string AnnouncementTitle { get; set; }
        public string AnnouncementDescription { get; set; }
        public DateTime AnnouncementDateCreated { get; set; }
        public DateTime AnnouncementDateModified { get; set; }
        public string AnnouncementUserModified { get; set; }
        public DateTime AnnouncementExpiryDate { get; set; }
        public string AnnouncementImportantIndicator { get; set; }
        public string AnnouncementImagePath { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Users User { get; set; }
    }
}
