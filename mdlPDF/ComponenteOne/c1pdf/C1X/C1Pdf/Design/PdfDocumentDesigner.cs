namespace C1.C1Pdf.Design
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;

    internal class PdfDocumentDesigner : ComponentDesigner
    {
        // Methods
        public PdfDocumentDesigner()
        {
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            this.Verbs.Add(new DesignerVerb(G.2K("About C1PdfDocument..."), new EventHandler(this.ShowAboutBox)));
        }

        private void ShowAboutBox(object sender, EventArgs e)
        {
            ProviderInfo.ShowAboutBox(base.Component);
        }

    }
}

