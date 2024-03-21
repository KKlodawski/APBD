// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
