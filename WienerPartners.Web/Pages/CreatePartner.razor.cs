using Microsoft.AspNetCore.Components;
using WienerPartners.Core.Models;
using WienerPartners.Data;

namespace WienerPartners.Web.Pages
{
    public class CreatePartnerBase : ComponentBase
    {
        [Inject] 
        protected IPartnerRepository Repo { get; set; } = default!;

        [Inject] 
        protected NavigationManager NavigationManager { get; set; } = default!;

        protected Partner Model = new Partner();

        protected async Task HandleValidSubmit()
        {
            try
            {
                var id = await Repo.CreateAsync(Model);
                NavigationManager.NavigateTo($"/?newId={id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
