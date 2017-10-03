using System;

namespace GoshoSoft.ForumSystem.Models.Interfaces
{
    public interface IAuditable
    {
        DateTime? CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
