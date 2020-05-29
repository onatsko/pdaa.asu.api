﻿using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace pdaa.asu.api.Services
{
    public static class FileUtil
    {
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
            => js.InvokeAsync<object>(
                "saveAsFile",
                filename,
                Convert.ToBase64String(data));
    }
}
