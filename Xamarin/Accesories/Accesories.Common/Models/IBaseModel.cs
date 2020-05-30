using System;
using System.Collections.Generic;
using System.Text;

namespace Accesories.Common.Models
{
    public interface IBaseModel
    {
        DateTimeOffset TimeStamp { get; set; }
    }
}
