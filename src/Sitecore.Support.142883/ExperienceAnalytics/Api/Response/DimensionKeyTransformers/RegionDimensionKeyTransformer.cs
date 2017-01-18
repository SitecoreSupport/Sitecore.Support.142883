using Sitecore.ExperienceAnalytics.Api.Response.DimensionKeyTransformers;
using Sitecore.ExperienceAnalytics.Core.Grouping;
using Sitecore.Globalization;
using Sitecore.Support.ExperienceAnalytics.Api.Grouping;

namespace Sitecore.Support.ExperienceAnalytics.Api.Response.DimensionKeyTransformers
{
  public class RegionDimensionKeyTransformer : IDimensionKeyTransformer
  {
    private readonly IVisitGroupLabeler regionGroupLabeler = new RegionLabeler();

    public string UnknownLabel
    {
      get
      {
        return "[unknown region]";
      }
    }

    public string Transform(string key, Language language)
    {
      return Translate.Text(this.regionGroupLabeler.GetLabel(key, language));
    }
  }
}