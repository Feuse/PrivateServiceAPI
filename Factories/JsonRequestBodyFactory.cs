﻿
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ServicesInterfaces;
using ServicesInterfaces.Global;
using ServicesModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BadooAPI.Factories
{
    public class JsonRequestBodyFactory : IJsonFactory
    {
        public dynamic GetJson(JsonTypes types)
        {
            var json = File.ReadAllText(GetSettingsFromFile());
            var deserialziedJson = JsonConvert.DeserializeObject<dynamic>(json);
            switch (types)
            {
                case JsonTypes.Login:
                    return deserialziedJson.Login;
                case JsonTypes.LoginAM:
                    return deserialziedJson.LoginAM;
                case JsonTypes.LoginUS:
                    return deserialziedJson.LoginUS;
                case JsonTypes.SERVER_APP_STARTUP:
                    return deserialziedJson.AppStartup;
                case JsonTypes.GetSearchSettings:
                    return deserialziedJson.GetSearchSettings.data;
                case JsonTypes.GetEncounters:
                    return deserialziedJson.GetEncounters;
                case JsonTypes.Vote:
                    return deserialziedJson.Vote.data;
                case JsonTypes.SearchLocations:
                    return deserialziedJson.SearchLocations.data;
                case JsonTypes.UpdateAboutMe:
                    return deserialziedJson.UpdateAboutMe;
                case JsonTypes.SaveLocation:
                    return deserialziedJson.SaveLocation.data;
                case JsonTypes.UploadPhoto:
                    return deserialziedJson.UploadPhoto.data;
                case JsonTypes.RemoveImage:
                    return deserialziedJson.RemoveImage;
                case JsonTypes.MakeProfilePhoto:
                    return deserialziedJson.MakeProfilePhoto.data;
                case JsonTypes.GetImages:
                    return deserialziedJson.GetImages;
                case JsonTypes.Like:
                    return deserialziedJson.Like;
                default:
                    break;
            }
            return default;
        }
        private static string GetSettingsFromFile()
        {
            var confBuilder = new ConfigurationBuilder()
                       //what will be the current directory on production server?
                       .SetBasePath(Environment.CurrentDirectory)
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            var val = confBuilder.GetSection("AppSettings:JsonRequestsPath").Value;

            return confBuilder.GetSection("AppSettings:JsonRequestsPath").Value;
        }
    }
}
