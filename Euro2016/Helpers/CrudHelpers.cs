using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Omu.AwesomeMvc;

namespace Euro2016.Helpers
{
    public static class CrudHelpers
    {
        public static IHtmlString InitCrudPopupsForGrid<T>(this HtmlHelper<T> html, string gridId, string crudController, int createPopupHeight = 430)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);

            var result =
            html.Awe()
                .InitPopupForm()
                .Name("create" + gridId)
                .Group(gridId)
                .Height(createPopupHeight)
                .Url(url.Action("Create", crudController))
                .Success("utils.itemCreated('" + gridId + "')")
                .ToString()

            + html.Awe()
                  .InitPopupForm()
                  .Name("edit" + gridId)
                  .Group(gridId)
                  .Height(createPopupHeight)
                  .Url(url.Action("Edit", crudController))
                  .Modal(true)
                  .Success("utils.itemEdited('" + gridId + "')")

            + html.Awe()
                  .InitPopupForm()
                  .Name("delete" + gridId)
                  .Group(gridId)
                  .Url(url.Action("Delete", crudController))
                  .Success("utils.itemDeleted('" + gridId + "')")
                  .OnLoad("utils.delConfirmLoad('" + gridId + "')") // calls grid.api.select and animates the row
                  .Height(200)
                  .Modal(true);

            return new MvcHtmlString(result);
        }

    }
}