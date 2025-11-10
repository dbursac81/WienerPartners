using Microsoft.AspNetCore.Components;
using WienerPartners.Core.Models;
using WienerPartners.Data;

namespace WienerPartners.Web.Pages;

public class IndexBase : ComponentBase
{
    [Inject]
    protected IPartnerRepository Repo { get; set; } = default!;

    [Inject]
    protected NavigationManager NavigationManager { get; set; } = default!;

    protected List<Partner>? Partners;
    protected Partner? SelectedPartner;
    protected int? NewId;

    protected bool ShowModal { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
        if (Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(uri.Query).TryGetValue("newId", out var idStr))
        {
            if (int.TryParse(idStr.FirstOrDefault(), out var id)) NewId = id;
        }
        await LoadAsync();
    }

    protected async Task LoadAsync()
    {
        Partners = (await Repo.GetAllAsync()).ToList();
    }

    protected async Task ShowDetails(int id)
    {
        SelectedPartner = await Repo.GetByIdAsync(id);
        ShowModal = true;
        StateHasChanged();
    }

    protected void HideModal()
    {
        ShowModal = false;
    }

    protected void OpenAddPolicy(int partnerId)
    {
        NavigationManager.NavigateTo($"/create-policy/{partnerId}");
    }
}
