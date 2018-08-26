
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViMail.Data.Entities
{
    public class DomainEntry<T>
    {
        [Key]
        public T Id { get; set; }

        [DefaultValue(false)]
        public bool IsInactive { get; set; } = false;

        [NotMapped]
        public bool IsTransient
        {
            get
            {
                return Id.Equals(default(T));
            }
        }
    }
}