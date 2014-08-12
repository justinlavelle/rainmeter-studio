﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RainmeterStudio.Core.Documents;
using RainmeterStudio.Core.Model;

namespace RainmeterStudio.SkinDesignerPlugin
{
    /// <summary>
    /// Template of a skin which will be opened in the designer
    /// </summary>
    public class SkinTemplate : DocumentTemplate
    {
        /// <summary>
        /// Initializes this skin template
        /// </summary>
        public SkinTemplate()
            : base("Skin", "ini")
        {
        }

        /// <summary>
        /// Creates a new document using this template
        /// </summary>
        /// <returns>Newly created document</returns>
        public override IDocument CreateDocument()
        {
            return new SkinDocument();
        }
    }
}
