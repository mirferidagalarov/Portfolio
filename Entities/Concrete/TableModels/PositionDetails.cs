using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class PositionDetails:BaseEntity
    {
        public int PersonId { get; set; }    
        public int PositionId { get; set; }
        
    }
}
