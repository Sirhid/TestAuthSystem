using System;
using System.Collections.Generic;
using System.Text;

namespace TestAuthSystem.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
