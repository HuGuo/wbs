using System;
using System.Collections.Generic;
using System.Text;

namespace Wbs.Entity
{
    public class User
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}
