using Microsoft.AspNetCore.Components;
using WienerPartners.Core.Models;

namespace WienerPartners.Web.Shared;

public class PartnerDetailsModalBase : ComponentBase
{
    [Parameter] 
    public Partner? Partner { get; set; }

    [Parameter] 
    public bool Show { get; set; }

    [Parameter] 
    public EventCallback OnClose { get; set; }

    protected async Task OnCloseClicked()
    {
        Show = false;
        await OnClose.InvokeAsync();
    }
}
