using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebServer.Data;
using WebServer.Domain.Interfaces;
using WebServer.Domain.Queries;

namespace WebServer.Domain
{
    public partial class DataService : IDataService
    {
        private IDataContext _context;

        public DataService(IDataContext context)
        {
            _context = context;
        }
    }
}