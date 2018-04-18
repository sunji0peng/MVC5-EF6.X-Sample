using System.Web;
using System.Web.Optimization;

namespace Enuo.UniversityProject
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Js
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/AceJs").Include(
                "~/Scripts/AceJs/ace.js",
                "~/Scripts/AceJs/ace.ajax-content.js",
                "~/Scripts/AceJs/ace.touch-drag.js",
                "~/Scripts/AceJs/ace.sidebar.js",
                "~/Scripts/AceJs/ace.sidebar-scroll-1.js",
                 "~/Scripts/AceJs/ace.submenu-hover.js",
                "~/Scripts/AceJs/ace.widget-box.js",
                "~/Scripts/AceJs/ace.settings.js",
                "~/Scripts/AceJs/ace.settings-rtl.js",
                "~/Scripts/AceJs/ace.settings-skin.js",
                "~/Scripts/AceJs/ace.widget-on-reload.js",
                 "~/Scripts/AceJs/ace.searchbox-autocomplete.js"));
            bundles.Add(new ScriptBundle("~/bundles/AceElements").Include(
              "~/Scripts/AceJs/elements.scroller.js",
              "~/Scripts/AceJs/elements.colorpicker.js",
              "~/Scripts/AceJs/elements.fileinput.js",
              "~/Scripts/AceJs/elements.typeahead.js",
              "~/Scripts/AceJs/elements.wysiwyg.js",
              "~/Scripts/AceJs/elements.spinner.js",
              "~/Scripts/AceJs/elements.treeview.js",
              "~/Scripts/AceJs/elements.wizard.js",
              "~/Scripts/AceJs/elements.aside.js"));
            bundles.Add(new ScriptBundle("~/bundles/AceTablesJs").Include(
               "~/Scripts/AceJs/ace-extra.js"));
            #endregion


            #region Css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/BootstrapStyles").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css"));
            bundles.Add(new StyleBundle("~/AceStyles").Include(
                     "~/Content/AceCss/ace.css",
                    "~/Content/AceCss/ace-fonts.css",
                    "~/Content/AceCss/datepicker.css"));
            #endregion
        }
    }
}
