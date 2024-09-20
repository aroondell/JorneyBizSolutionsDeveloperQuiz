using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyBizDatabase.Entities
{
    public class User : IEntity
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public void CopyFrom(IEntity copyFrom)
        {
            if (copyFrom is not User) throw new Exception(nameof(copyFrom));
            
            User user = (User)copyFrom;
            this.Name = user.Name;
            this.Email = user.Email;
        }
    }
}
