#pragma checksum "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89c11dd96345aa9f6cbe55beb541e3c5fd8c8d37"
// <auto-generated/>
#pragma warning disable 1591
namespace MovieApp.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\_Imports.razor"
using MovieApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\_Imports.razor"
using MovieApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\_Imports.razor"
using MovieApp.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\_Imports.razor"
using MovieApp.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
using MovieApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
using MovieApp.Shared.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/movie/add")]
    public partial class MovieAdd : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>MovieAdd</h3>");
#nullable restore
#line 11 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
 if (persons != null && genres != null)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "form");
            __builder.AddAttribute(2, "class", "form-container");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "form-group");
            __builder.AddMarkupContent(5, "<label for=\"title\">Title:</label>\r\n      ");
            __builder.OpenElement(6, "input");
            __builder.AddAttribute(7, "type", "text");
            __builder.AddAttribute(8, "class", "form-control");
            __builder.AddAttribute(9, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 16 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
                                                     movie.Title

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => movie.Title = __value, movie.Title));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n\r\n    ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "form-group");
            __builder.AddMarkupContent(14, "<label for=\"summary\">Summary:</label>\r\n      ");
            __builder.OpenElement(15, "textarea");
            __builder.AddAttribute(16, "class", "form-control");
            __builder.AddAttribute(17, "rows", "3");
            __builder.AddAttribute(18, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 21 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
                                                     movie.Summary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(19, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => movie.Summary = __value, movie.Summary));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n\r\n    ");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", "form-group");
            __builder.AddMarkupContent(23, "<label for=\"inTheaters\">In Theaters:</label>\r\n      ");
            __builder.OpenElement(24, "input");
            __builder.AddAttribute(25, "type", "checkbox");
            __builder.AddAttribute(26, "class", "form-control");
            __builder.AddAttribute(27, "checked", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 26 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
                                                         movie.InTheaters

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(28, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => movie.InTheaters = __value, movie.InTheaters));
            __builder.SetUpdatesAttributeName("checked");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n\r\n    ");
            __builder.OpenElement(30, "div");
            __builder.AddAttribute(31, "class", "form-group");
            __builder.AddMarkupContent(32, "<label for=\"trailer\">Trailer:</label>\r\n      ");
            __builder.OpenElement(33, "input");
            __builder.AddAttribute(34, "type", "text");
            __builder.AddAttribute(35, "class", "form-control");
            __builder.AddAttribute(36, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 31 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
                                                     movie.Trailer

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(37, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => movie.Trailer = __value, movie.Trailer));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n\r\n    ");
            __builder.OpenElement(39, "div");
            __builder.AddAttribute(40, "class", "form-group");
            __builder.AddMarkupContent(41, "<label for=\"releaseDate\">Release Date:</label>\r\n      ");
            __builder.OpenElement(42, "input");
            __builder.AddAttribute(43, "type", "date");
            __builder.AddAttribute(44, "class", "form-control");
            __builder.AddAttribute(45, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 36 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
                                                     movie.ReleaseDate

#line default
#line hidden
#nullable disable
            , format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(46, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => movie.ReleaseDate = __value, movie.ReleaseDate, format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n\r\n    ");
            __builder.OpenElement(48, "div");
            __builder.AddAttribute(49, "class", "form-group");
            __builder.AddMarkupContent(50, "<label for=\"poster\">Poster:</label>\r\n      ");
            __builder.OpenElement(51, "input");
            __builder.AddAttribute(52, "type", "text");
            __builder.AddAttribute(53, "class", "form-control");
            __builder.AddAttribute(54, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 41 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
                                                     movie.Poster

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(55, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => movie.Poster = __value, movie.Poster));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\r\n\r\n    ");
            __builder.OpenElement(57, "div");
            __builder.AddAttribute(58, "class", "form-group");
            __builder.AddMarkupContent(59, "<label for=\"genres\">Genres:</label>\r\n      ");
            __builder.OpenElement(60, "select");
            __builder.AddAttribute(61, "class", "form-control");
            __builder.AddAttribute(62, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 46 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
                                          genre

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(63, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => genre = __value, genre));
            __builder.SetUpdatesAttributeName("value");
            __builder.OpenElement(64, "option");
            __builder.AddAttribute(65, "value", "0");
            __builder.AddContent(66, "None");
            __builder.CloseElement();
#nullable restore
#line 48 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
         foreach (var genre in genres)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(67, "option");
            __builder.AddAttribute(68, "value", 
#nullable restore
#line 50 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
                          genre.Id

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 50 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
__builder.AddContent(69, genre.Name);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 51 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(70, "\r\n\r\n    ");
            __builder.OpenElement(71, "div");
            __builder.AddAttribute(72, "class", "form-group");
            __builder.AddMarkupContent(73, "<label for=\"persons\">Persons:</label>\r\n      ");
            __builder.OpenElement(74, "select");
            __builder.AddAttribute(75, "class", "form-control");
            __builder.AddAttribute(76, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 57 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
                                          person

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(77, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => person = __value, person));
            __builder.SetUpdatesAttributeName("value");
            __builder.OpenElement(78, "option");
            __builder.AddAttribute(79, "value", "0");
            __builder.AddContent(80, "None");
            __builder.CloseElement();
#nullable restore
#line 59 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
         foreach (var person in persons)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(81, "option");
            __builder.AddAttribute(82, "value", 
#nullable restore
#line 61 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
                          person.Id

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 61 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
__builder.AddContent(83, person.Name);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 62 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(84, "\r\n    ");
            __builder.OpenElement(85, "div");
            __builder.AddAttribute(86, "class", "form-group");
            __builder.AddMarkupContent(87, "<label for=\"poster\">Character:</label>\r\n      ");
            __builder.OpenElement(88, "input");
            __builder.AddAttribute(89, "type", "text");
            __builder.AddAttribute(90, "class", "form-control");
            __builder.AddAttribute(91, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 67 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
                                                     character

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(92, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => character = __value, character));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(93, "\r\n    ");
            __builder.OpenElement(94, "div");
            __builder.AddAttribute(95, "class", "form-group");
            __builder.AddMarkupContent(96, "<label for=\"poster\">Order:</label>\r\n      ");
            __builder.OpenElement(97, "input");
            __builder.AddAttribute(98, "type", "number");
            __builder.AddAttribute(99, "class", "form-control");
            __builder.AddAttribute(100, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 71 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
                                                       order

#line default
#line hidden
#nullable disable
            , culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(101, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => order = __value, order, culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(102, "\r\n    \r\n    ");
            __builder.OpenElement(103, "button");
            __builder.AddAttribute(104, "type", "button");
            __builder.AddAttribute(105, "class", "btn btn-primary");
            __builder.AddAttribute(106, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 74 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
                                                            AddMovie

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(107, "Submit");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 76 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(108, "<p>Loading</p>");
#nullable restore
#line 80 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(109, "<a class=\"btn btn-info\" href=\"/movies\">Powrót</a>");
        }
        #pragma warning restore 1998
#nullable restore
#line 84 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\MovieAdd.razor"
       
    public Movie movie { get; set; } = new Movie();
    public List<Genre> genres { get; set; } = new List<Genre>();
    public List<Person> persons { get; set; } = new List<Person>();
    public int genre { get; set; }
    public int person { get; set; }
    public string? character { get; set; } = null;
    public int? order { get; set; } = null;
    
    protected async override Task OnInitializedAsync()
    {
        await GetInfo();
    }

    private async Task GetInfo()
    {
      var responseHTTPgenres = await httpClient.GetAsync($"https://localhost:44311/api/movies/genres");
      var responseHTTPpersons = await httpClient.GetAsync($"https://localhost:44311/api/movies/persons");
      
      if (responseHTTPgenres.IsSuccessStatusCode && responseHTTPpersons.IsSuccessStatusCode)
        {
            var responseStringGenres = await responseHTTPgenres.Content.ReadAsStringAsync();
            var responseStringPersons = await responseHTTPpersons.Content.ReadAsStringAsync();
            
            genres = System.Text.Json.JsonSerializer.Deserialize<List<Genre>>(responseStringGenres, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            persons = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(responseStringPersons, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }
    }

  public async Task AddMovie()
  {
    if (movie.Title != null && movie.Summary != null && movie.Trailer != null && movie.ReleaseDate != null && movie.Poster != null)
    {
      if (person != 0 && (character == null || order == null)) await js.InvokeVoidAsync("alert", "Brakuje danych dotyczących osoby");
      else
      {
        MovieAddDto newMovie = new MovieAddDto
        {
          Title = movie.Title,
          Summary = movie.Summary,
          InTheaters = movie.InTheaters,
          Trailer = movie.Trailer,
          ReleaseDate = movie.ReleaseDate,
          Poster = movie.Poster,
          GenreId = genre,
          PersonId = person,
          Character = character,
          Order = order
        };
        var json = JsonSerializer.Serialize(newMovie);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var responseHTTP = await httpClient.PostAsync($"https://localhost:44311/api/movies/add", content);
        if (responseHTTP.IsSuccessStatusCode) await js.InvokeVoidAsync("alert", "Dodano pomyślnie!");
        else await js.InvokeVoidAsync("alert", "Dodanie nie powiodło się!");
      }
    }
    else
    {
      await js.InvokeVoidAsync("alert", "Nie podano wszyskich danych!");
    }
  }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient httpClient { get; set; }
    }
}
#pragma warning restore 1591