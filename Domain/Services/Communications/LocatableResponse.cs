using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class LocatableResponse : BaseResponse
    {
        public Locatable Locatable { get; protected set; }
        public LocatableResponse(bool success, string message, Locatable locatable) : base(success, message)
        {
            Locatable = locatable;
        }

        public LocatableResponse(string message) : this(false, message, null) { }
        public LocatableResponse(Locatable locatable) : this(true, string.Empty, locatable) { }
    }
}
