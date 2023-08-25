using API.Entities.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static API.Entities.Interface.IEntity;

namespace API.Entities
{
    public class BaseEntity <T> :IEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T? Id { get; set; }
        public virtual bool? isDelete { get; set; } = false;
    }
    public abstract class BaseEntity : BaseEntity<Guid>
    {
    }

}
