using Application.Common.Interfaces;
using Application.Common.Interfaces.Utility;

namespace Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}