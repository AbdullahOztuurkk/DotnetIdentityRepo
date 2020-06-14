using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWebUI.Entities.Abstract;

namespace CourseWebUI.Entities.Concrete
{
    public class UserCourse:IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CourseId { get; set; }

        public virtual Course _Course { get; set; }

        public virtual Student _Student { get; set; }
    }
}
