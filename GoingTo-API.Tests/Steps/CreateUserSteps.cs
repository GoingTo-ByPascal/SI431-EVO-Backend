using GoingTo_API.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GoingTo_API.Tests.Steps
{
    class CreateUserSteps
    {
        private IRestResponse _restResponse;
        private Property _property;
        private HttpStatusCode _statusCode;
        private List<User> _properties;
    }
}
