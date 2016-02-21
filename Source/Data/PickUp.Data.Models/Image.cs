using PickUp.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickUp.Data.Models
{
    public class Image : BaseModel<int>
    {
        public new int? Id { get; set; }

        public string FileName { get; set; }

        public byte[] Content { get; set; }

        public string Extension { get; set; }
    }
}
