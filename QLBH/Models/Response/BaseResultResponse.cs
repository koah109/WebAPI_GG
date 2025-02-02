﻿namespace QLBH.Models.Response
{
    public class BaseResultResponse<T>
    {
        public int Status { get; set; }

        public string? Message { get; set; }

        public T? Result { get; set; }
    }
}
