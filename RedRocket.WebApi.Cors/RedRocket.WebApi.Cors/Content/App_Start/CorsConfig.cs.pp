using System;
using System.Web.Http;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(UtahsOwn.Api.App_Start.CorsConfig), "PreStart")]

namespace UtahsOwn.Api.App_Start {
    public static class CorsConfig {
        public static void PreStart() {
            GlobalConfiguration.Configuration.MessageHandlers.Add(new RedRocket.WebApi.Cors.CorsHandler());
        }
    }
}

