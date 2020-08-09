﻿

using System.Globalization;

namespace UBS.Resources
{
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class translations
    {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal translations()
        {
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UBS.Resources.translations", typeof(translations).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to WealthManagement.
        /// </summary>
        internal static string WealthManagement(CultureInfo currentLanguage)
        {
            resourceCulture = currentLanguage;
            return ResourceManager.GetString("WealthManagement", resourceCulture);
        }

        /// <summary>
        ///   Looks up a localized string similar to AssetManagement.
        /// </summary>
        internal static string AssetManagement(CultureInfo currentLanguage)
        {
            resourceCulture = currentLanguage;
            return ResourceManager.GetString("AssetManagement", resourceCulture);
        }

        /// <summary>
        ///   Looks up a localized string similar to InvestmentBank.
        /// </summary>
        internal static string InvestmentBank(CultureInfo currentLanguage)
        {
            resourceCulture = currentLanguage;
            return ResourceManager.GetString("InvestmentBank", resourceCulture);
        }

        /// <summary>
        ///   Looks up a localized string similar to AboutUs.
        /// </summary>
        internal static string AboutUs(CultureInfo currentLanguage)
        {
            resourceCulture = currentLanguage;
            return ResourceManager.GetString("AboutUs", resourceCulture);
        }

        /// <summary>
        ///   Looks up a localized string similar to Careers.
        /// </summary>
        internal static string Careers(CultureInfo currentLanguage)
        {
            resourceCulture = currentLanguage;
            return ResourceManager.GetString("Careers", resourceCulture);
        }
    }
}
