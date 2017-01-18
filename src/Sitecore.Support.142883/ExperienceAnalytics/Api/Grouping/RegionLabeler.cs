using Sitecore.Diagnostics;
using Sitecore.ExperienceAnalytics.Api;
using Sitecore.ExperienceAnalytics.Core.Grouping;
using Sitecore.Globalization;
using Sitecore.StringExtensions;
using Sitecore.Support.ExperienceAnalytics.Api.GeoLocationTranslations;
using System;

namespace Sitecore.Support.ExperienceAnalytics.Api.Grouping
{
  public class RegionLabeler : IVisitGroupLabeler
  {
    public string GetLabel(string groupId, Language language)
    {
      Assert.IsNotNullOrEmpty(groupId, "key");
      try
      {
        return ((groupId == "ZZ") ? "[unknown region]" : GetRegionTranslation(groupId));
      }
      catch (Exception)
      {
        object[] parameters = new object[] { groupId };
        ApiContainer.GetLogger().Warn("Could not resolve dimension key for region: '{0}'".FormatWith(parameters));
        return "[unknown region]";
      }
    }

    private static string GetRegionTranslation(string regionCode)
    {
      return typeof(Regions).GetField(regionCode).GetValue(null) as string;
    }
  }
}
