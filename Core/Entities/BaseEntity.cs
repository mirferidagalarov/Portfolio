using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Unique Identity
        /// </summary>
        public int ID { get; set; }
    }
}
