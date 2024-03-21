// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace MovieApp.Client.Shared
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
    public partial class MoviesList : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 13 "E:\Sem4\APBD\cwiczenia12_jb-KKlodawski\MovieApp\Client\Shared\MoviesList.razor"
       
    [Parameter] public List<Movie> Movies { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    private async Task DeleteMovie(Movie movie)
    {
        await js.MyFunction("custom message");
        var confirmed = await js.Confirm($"Are you sure you want to delete {movie.Title}?");
        
        if (confirmed)
        {
            var responseHTTP = await httpClient.DeleteAsync($"https://localhost:44311/api/movies/del/{movie.Id}");
            
            if (responseHTTP.IsSuccessStatusCode)
            {
                Movies.Remove(movie);
                await js.InvokeVoidAsync("alert", "Usunięto film!");
            }
            else
            {
                await js.InvokeVoidAsync("alert", "Nie udało się usunąć filmu!");
            }
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient httpClient { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
    }
}
#pragma warning restore 1591
