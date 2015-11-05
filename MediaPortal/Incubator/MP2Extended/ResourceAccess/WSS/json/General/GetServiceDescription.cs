﻿using HttpServer;
using MediaPortal.Common;
using MediaPortal.Common.Logging;
using MediaPortal.Plugins.MP2Extended.WSS.General;

namespace MediaPortal.Plugins.MP2Extended.ResourceAccess.WSS.json.General
{
  internal class GetServiceDescription : IRequestMicroModuleHandler
  {
    public dynamic Process(IHttpRequest request)
    {
      WebStreamServiceDescription webStreamServiceDescription = new WebStreamServiceDescription
      {
        ApiVersion = GlobalVersion.API_VERSION,
        ServiceVersion = GlobalVersion.VERSION,
        SupportsMedia = true,
        SupportsRecordings = false,
        SupportsTV = false
      };


      return webStreamServiceDescription;
    }

    internal static ILogger Logger
    {
      get { return ServiceRegistration.Get<ILogger>(); }
    }
  }
}