using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.ViewModels
{
    public class PersonViewModel
    {
        public Person People { get; set; }
        public Position Positions { get; set; }
    }
}
