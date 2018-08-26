using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViMail.Data.Entities
{
    [Table("Emails")]
    public class Email : DomainEntry<Guid>
    {
        
    }
}