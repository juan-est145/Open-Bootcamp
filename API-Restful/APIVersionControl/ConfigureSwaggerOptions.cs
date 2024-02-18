﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace APIVersionControl
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "My .Net API restful",
                Version = description.ApiVersion.ToString(),
                Description = "This is my first API Versioning control",
                Contact = new OpenApiContact()
                {
                    Email = "martin@gmail.com",
                    Name = "Martín",
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "This API version has been deprecated";
            }

            return info;
        }

        public void Configure(SwaggerGenOptions options)
        {
            //Add Swagger Documentation for each API version we have
            foreach (var descripcion in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(descripcion.GroupName, CreateVersionInfo(descripcion));
            }
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }
    }
}
