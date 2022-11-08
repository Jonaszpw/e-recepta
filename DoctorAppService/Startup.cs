//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace DoctorAppService
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.HttpsPolicy;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;
  using Microsoft.Extensions.Logging;
  using Microsoft.OpenApi.Models;

  public class Startup
  {
    public Startup( IConfiguration configuration )
    {
      this.Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices( IServiceCollection services )
    {
      services.AddControllers( );
      
      services.AddSwaggerGen( options => { options.SwaggerDoc( "v1", new OpenApiInfo { Title = "doctorAppService", Version = "v1" } ); } );
    }

    public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
    {
      if( env.IsDevelopment( ) )
      {
        app.UseDeveloperExceptionPage( );

        app.UseSwagger( );

        app.UseSwaggerUI( options => options.SwaggerEndpoint( "/swagger/v1/swagger.json", "doctorAppService v1") );
      }
      /* AT
      app.UseHttpsRedirection( );
      */
      app.UseRouting( );

      app.UseAuthorization( );

      app.UseEndpoints( endpoints => { endpoints.MapControllers( ); } );
    }
  }
}
