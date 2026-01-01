using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManagemant.Domain.Exceptions
{
    public class DomainException(string message) : Exception(message)
    {
    }
}
