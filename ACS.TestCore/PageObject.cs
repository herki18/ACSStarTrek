using System;

namespace ACS.TestCore
{
    public abstract class PageObject : IDisposable
    {
        public TFDriver Engine { get; private set; }

        protected PageObject()
        {
            Engine = new TFDriver();
        }

        public void Dispose()
        {
            Engine.Dispose();
        }
    }
}
