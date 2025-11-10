using Microsoft.AspNetCore.Components;
using WienerPartners.Core.Models;
using WienerPartners.Data;

namespace WienerPartners.Web.Pages;

public class CreatePolicyBase : ComponentBase
{
    [Parameter]
    public int PartnerId { get; set; }

    [Inject]
    protected IPolicyRepository repo { get; set; } = default!;

    [Inject]
    protected IPartnerRepository partnerRepo { get; set; } = default!;

    [Inject]
    protected NavigationManager navigationManager { get; set; } = default!;

    protected Policy Model = new Policy();

    protected string FullName { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        var policy = await repo.GetByPartnerIdAsync(PartnerId);

        var partner = await partnerRepo.GetByIdAsync(PartnerId);
        if (partner != null)
            FullName = partner.FullName;
    }

    protected override void OnInitialized()
    {
        Model.PartnerId = PartnerId;
    }

    protected async Task HandleValidSubmit()
    {
        await repo.CreateAsync(Model);
        navigationManager.NavigateTo("/");
    }

    protected void Cancel()
    {
        navigationManager.NavigateTo("/");
    }
}
