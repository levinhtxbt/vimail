using System;

namespace ViMail.Data.Interfaces
{
    public interface IHasTrackingModify
    {
        int? ModifiedBy { get; set; }

        DateTime? ModifiedAt { get; set; }
    }
}