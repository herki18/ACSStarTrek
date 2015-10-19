using System;

namespace ACS.TestCore
{
    public abstract class PageObject : IDisposable
    {
        public TFDriver Engine { get; private set; }

        protected PageObject()
        {
        }

        protected void Initialize()
        {
            Engine = new TFDriver();
        }
        

        public void Dispose()
        {
            Engine.Dispose();
        }
    }
}
