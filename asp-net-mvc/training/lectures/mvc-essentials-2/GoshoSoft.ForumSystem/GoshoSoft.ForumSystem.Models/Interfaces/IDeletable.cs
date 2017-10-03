using System;

namespace GoshoSoft.ForumSystem.Models.Interfaces
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
