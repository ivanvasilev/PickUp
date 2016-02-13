namespace PickUp.Data.Models
{
    using System.Collections.Generic;
    using PickUp.Data.Common.Models;

    public class Location : BaseModel<int>
    {
        public string Name { get; set; }
    }
}