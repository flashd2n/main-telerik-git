using Academy.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.ModelsTests.Abstractions
{
    public class FakeUser : User
    {
        public FakeUser(string username) : base(username)
        {
        }
    }
}
