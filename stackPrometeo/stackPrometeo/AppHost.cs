using System.Configuration;

using Funq;
using ServiceStack;
using ServiceStack.Text;
using stackPrometeo.ServiceInterface;
using stackPrometeo.Services.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;



namespace stackPrometeo
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyAspNet
    public class AppHost : AppHostBase
    {
        
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("stackPrometeo", typeof(ClientService).Assembly) {

            JsConfig.EmitCamelCaseNames = true;


        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            container.Register(_ => new ClientListing());

            //container.Register(_ => new ClientListing {
            //new EntityClient("Evelio", "Gil"){Zip = 34786},
            //new EntityClient("Fernand", "Gil"),
            //new EntityClient("Veronica", "Sofia"){Address = "Windermere"},
            //new EntityClient("Gabriela", "Gil"){Country = "USA"}
            //});


            using (JsConfig.BeginScope())
            {
                JsConfig.DateHandler = DateHandler.ISO8601;
                ; // some JSON serialization code
            }
        }
    }
}