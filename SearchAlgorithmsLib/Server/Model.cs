﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Server
{
    public class Model
    {
        private IController controller;
        public IController Controller
        {
            get
            {
                return controller;
            }

            set
            {
                controller = value;
            }
        }

        public Model()
        {

        }

 
        public string HandleRequest(string option, Socket client)
        {
           

    
        }
    }
}