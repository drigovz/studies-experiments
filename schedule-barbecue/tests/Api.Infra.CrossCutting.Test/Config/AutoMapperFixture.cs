using System;
using Api.Infra.CrossCutting.Mappings;
using AutoMapper;

namespace Api.Infra.CrossCutting.Test.Config
{
   public class AutoMapperFixture : IDisposable
   {
      public IMapper Mapper {get; set;}

      public IMapper GetMapper()
      {
         var config = new MapperConfiguration(cfg => {
            cfg.AddProfile(new DtoToModelProfile());
         });

         return config.CreateMapper();
      }

      public void Dispose()
      {
      }
   }
}
