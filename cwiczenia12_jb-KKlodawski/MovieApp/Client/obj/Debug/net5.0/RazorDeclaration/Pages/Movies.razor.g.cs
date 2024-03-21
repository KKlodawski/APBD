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
#line 2 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\Movies.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\Movies.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\Movies.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/movies")]
    public partial class Movies : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 17 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Pages\Movies.razor"
       

    private List<Movie> MoviesListTheaters;
    private List<Movie> MoviesListNonTheaters;
    protected async override Task OnInitializedAsync()
    {
        await GetMovies();
    }

    private async Task GetMovies()
    {
        var responseHTTP = await httpClient.GetAsync("https://localhost:44311/api/movies");

        if (responseHTTP.IsSuccessStatusCode)
        {
            List<Movie> responseList;
            var responseString = await responseHTTP.Content.ReadAsStringAsync();
            responseList = System.Text.Json.JsonSerializer.Deserialize<List<Movie>>(responseString, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            MoviesListTheaters = responseList.Where(e => e.InTheaters == true).ToList();
            MoviesListNonTheaters = responseList.Where(e => e.InTheaters == false).ToList();
        }
        else
        {
            await js.InvokeVoidAsync("alert", "Nie udało się wczytać filmu!");
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