using Nancy;
using Nancy.ErrorHandling;
using Nancy.ViewEngines;
using System;
using System.Linq;

namespace NancyVsMvc.Nancy
{
    public class Custom404Handler : IStatusCodeHandler
    {
        private readonly IViewFactory viewFactory;

        public Custom404Handler(IViewFactory viewFactory)
        {
            if (viewFactory == null)
            {
                throw new ArgumentNullException("viewFactory");
            }

            this.viewFactory = viewFactory;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var viewRenderer = new DefaultViewRenderer(viewFactory);
            var response = viewRenderer.RenderView(context, "404");
            context.Response = response;
            context.Response.StatusCode = HttpStatusCode.NotFound;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound;
        }
    }
}