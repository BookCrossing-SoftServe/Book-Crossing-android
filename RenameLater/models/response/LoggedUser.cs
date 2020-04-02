using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace RenameLater.models.response
{
    public class LoggedUser
    {
        [JsonProperty(Required = Required.Always)]
        public string Token { get; set; }

        [DefaultValue(null)]
        public string Email { get; set; }

        [DefaultValue(null)]
        public string LastName { get; set; }

        [DefaultValue(null)]
        public string FirstName { get; set; }
    }
}
