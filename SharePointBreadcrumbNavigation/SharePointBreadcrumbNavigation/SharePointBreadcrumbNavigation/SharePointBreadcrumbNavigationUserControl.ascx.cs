using Microsoft.SharePoint.Publishing;
using Microsoft.SharePoint.Publishing.Navigation;
using Microsoft.SharePoint.WebControls;
using System;
using System.Web;
using System.Web.UI;

namespace SharePointBreadcrumbNavigation.SharePointBreadcrumbNavigation
{
    public partial class SharePointBreadcrumbNavigationUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page is UnsecuredLayoutsPageBase)
            {
                ContentMap.SiteMapProvider = "SPXmlContentMapProvider";
            }
            else if (Page is PublishingLayoutPage)
            {
                ContentMap.RenderCurrentNodeAsLink = true;

                PortalSiteMapProvider provider = SiteMap.Providers["CurrentNavSiteMapProviderNoEncode"] as PortalSiteMapProvider;

                if (provider != null)
                {
					provider.IncludePages = PortalSiteMapProvider.IncludeOption.Always;
					provider.IncludeSubSites = PortalSiteMapProvider.IncludeOption.Always;
					ContentMap.Provider = provider;
                }
                else
                {
                    ContentMap.SiteMapProvider = "CurrentNavSiteMapProviderNoEncode";
                }
            }
            else
            {
                ContentMap.SiteMapProvider = "SPContentMapProvider";
            }
        }
    }
}
