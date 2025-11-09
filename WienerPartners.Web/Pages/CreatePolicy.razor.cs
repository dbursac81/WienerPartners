using Microsoft.AspNetCore.Components;
using WienerPartners.Core.Models;
using WienerPartners.Data;

namespace WienerPartners.Web.Pages
{
    public class CreatePolicyBase : ComponentBase
    {
        [Parameter] public int PartnerId { get; set; }
        [Inject] protected IPartnerRepository Repo { get; set; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

        protected Policy Model = new Policy();

        protected override void OnInitialized()
        {
            Model.PartnerId = PartnerId;
        }

        protected async Task HandleValidSubmit()
        {
            await Repo.CreatePolicyAsync(Model);
            NavigationManager.NavigateTo("/");
        }
    }
}
