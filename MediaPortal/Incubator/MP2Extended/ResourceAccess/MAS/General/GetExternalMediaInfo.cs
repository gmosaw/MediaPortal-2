﻿using HttpServer;
using HttpServer.Exceptions;
using MediaPortal.Common;
using MediaPortal.Common.Logging;
using MediaPortal.Plugins.MP2Extended.MAS.General;

namespace MediaPortal.Plugins.MP2Extended.ResourceAccess.MAS.General
{
  // TODO: don't really know what the pupose of this method is.
  internal class GetExternalMediaInfo : IRequestMicroModuleHandler
  {
    public dynamic Process(IHttpRequest request)
    {
      Logger.Info("MAS-GetMediaItem: AbsolutePath: {0}, uriParts.Length: {1}, Lastpart: {2}", request.Uri.AbsolutePath);

      HttpParam httpParam = request.Param;
      string id = httpParam["id"].Value;
      if (id == null)
        throw new BadRequestException("GetMediaItem: no id is null");


      WebDictionary<string> webDictionary = new WebDictionary<string>
      {
        { "Id", id }
      };

      return webDictionary;
    }

    internal static ILogger Logger
    {
      get { return ServiceRegistration.Get<ILogger>(); }
    }
  }
}