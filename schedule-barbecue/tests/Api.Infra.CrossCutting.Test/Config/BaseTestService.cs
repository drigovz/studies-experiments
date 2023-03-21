using AutoMapper;

namespace Api.Infra.CrossCutting.Test.Config
{
   public abstract class BaseTestService
   {
      public IMapper mapper { get; set; }

      public BaseTestService()
      {
         mapper = new AutoMapperFixture().GetMapper();
      }
   }
}