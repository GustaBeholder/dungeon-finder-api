﻿using System.Text.Json.Serialization;

namespace DungeonFinderAPI.Model.Response
{
    public class BaseResponse
    {
        
        public int ErrorCode { get; set; }
        
        public string Message { get; set; }
    }
}
