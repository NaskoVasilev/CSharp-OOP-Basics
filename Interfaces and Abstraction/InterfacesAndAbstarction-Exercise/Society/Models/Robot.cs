using Society.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Society.Models
{
    public class Robot : IIdentifiable
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model
        {
            get { return model; }
            private set { model = value; }
        }

        public string Id
        {
            get { return id; }
            private set { id = value; }
        }

    }
}
