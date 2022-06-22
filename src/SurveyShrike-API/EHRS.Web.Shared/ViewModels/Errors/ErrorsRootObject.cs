﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EHRS.Web.Shared.Models
{
    public class ErrorsRootObject : ISerializableObject
    {
        [JsonProperty("errors")]
        public Dictionary<string, List<string>> Errors { get; set; }

        public string GetPrimaryPropertyName()
        {
            return "errors";
        }

        public Type GetPrimaryPropertyType()
        {
            return Errors.GetType();
        }
    }
}