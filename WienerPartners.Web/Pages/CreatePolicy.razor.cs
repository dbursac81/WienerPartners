using Microsoft.AspNetCore.Components;
using WienerPartners.Core.Models;
using WienerPartners.Data;

namespace WienerPartners.Web.Pages
{
    public class CreatePolicyBase : ComponentBase
    {
        [Parameter] 
        public int PartnerId { get; set; }

        [Inject] 
        protected IPartnerRepository Repo { get; set; } = default!;

        [Inject] 
        protected NavigationManager NavigationManager { get; set; } = default!;

        protected Policy Model = new Policy();

        protected string FullName { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            var partner = await Repo.GetByIdAsync(PartnerId);
            if (partner != null)
                FullName = partner.FullName;
        }

        protected override void OnInitialized()
        {
            Model.PartnerId = PartnerId;
        }

        protected async Task HandleValidSubmit()
        {
            await Repo.CreatePolicyAsync(Model);
            NavigationManager.NavigateTo("/");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
