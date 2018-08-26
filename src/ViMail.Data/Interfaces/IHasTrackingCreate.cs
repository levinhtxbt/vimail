using System;

namespace ViMail.Data.Interfaces
{
    public interface IHasTrackingCreate
    {
        int? CreatedBy { get; set; }

        DateTime CreatedAt { get; set; }
    }
}