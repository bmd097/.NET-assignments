using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.HtmlHelpers {
    public static class Helpers {
        public static MvcHtmlString CountryFormHelper(
            this HtmlHelper htmlHelper,
            ResultModel model,
            String action
        ) {
            var form = new TagBuilder("form");
            form.MergeAttribute("class", "box");
            form.MergeAttribute("method", "POST");
            form.MergeAttribute("action", action);

            var img = new TagBuilder("img");
            img.MergeAttribute("src", "/Assets/india.jpg");
            img.MergeAttribute("id", "pictureId");
            form.InnerHtml += img.ToString();

            var divCountry = new TagBuilder("div");
            divCountry.MergeAttribute("class", "row");

            var selectCountry = new TagBuilder("select");
            selectCountry.MergeAttribute("name", "country");
            selectCountry.MergeAttribute("onchange", "runThis()");
            selectCountry.MergeAttribute("id", "countryId");

            foreach (var country in model.Countries.GetCounties()) {
                var option = new TagBuilder("option");
                option.MergeAttribute("value", country.Code);
                option.InnerHtml += country.Name;
                if (country.Code == model.CountryCodeSelected) {
                    option.MergeAttribute("selected", "selected");
                }
                selectCountry.InnerHtml += option.ToString();
            }

            divCountry.InnerHtml += selectCountry.ToString();
            divCountry.InnerHtml += "<button class=\"btn btn-primary\">Load</button>";
            form.InnerHtml += divCountry.ToString();

            // Cities Display
            if (model.Cities != null && model.Cities.Count > 0) {
                var divCity = new TagBuilder("div");
                divCity.MergeAttribute("class", "row");

                var selectCity = new TagBuilder("select");
                selectCity.MergeAttribute("name", "city");

                foreach (var city in model.Cities) {
                    var option = new TagBuilder("option");
                    option.MergeAttribute("value", city);
                    option.InnerHtml += city.ToString();
                    if (city == model.CitySelected) {
                        option.MergeAttribute("selected", "selected");
                    }
                    selectCity.InnerHtml += option.ToString();
                }

                var buttonCity = new TagBuilder("button");
                buttonCity.MergeAttribute("class", "btn btn-success");
                buttonCity.InnerHtml += "Load".ToString();

                divCity.InnerHtml += selectCity.ToString();
                divCity.InnerHtml += buttonCity.ToString();
                form.InnerHtml += divCity.ToString();
            }

            // Districts Display
            if (model.Districts != null && model.Districts.Count > 0) {
                var divDistrict = new TagBuilder("div");
                divDistrict.MergeAttribute("class", "row");

                var selectDistrict = new TagBuilder("select");
                selectDistrict.MergeAttribute("name", "district");

                foreach (var district in model.Districts) {
                    var option = new TagBuilder("option");
                    option.MergeAttribute("value", district);
                    option.InnerHtml += district.ToString();
                    selectDistrict.InnerHtml += option.ToString();
                }

                var buttonDistrict = new TagBuilder("button");
                buttonDistrict.MergeAttribute("class", "btn btn-dark");
                buttonDistrict.MergeAttribute("onclick", "alert('OK!')");
                buttonDistrict.InnerHtml += "Request".ToString();

                divDistrict.InnerHtml += selectDistrict.ToString();
                divDistrict.InnerHtml += buttonDistrict.ToString();
                form.InnerHtml += divDistrict.ToString();
            }

            return MvcHtmlString.Create(form.ToString());
        }
    }
}