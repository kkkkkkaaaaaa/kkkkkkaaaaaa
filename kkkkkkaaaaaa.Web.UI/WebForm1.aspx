<%@ Page Language="C#" %>
<%@ Import Namespace="System.Threading" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        var username = @"a";
        var password = @"b";
        if (!Membership.ValidateUser(username, @"")) { return; }

        var u = Membership.CreateUser(username, password);
        
        //var user = Membership.GetUser(username);

        //FormsAuthentication.RedirectFromLoginPage(user.ProviderUserKey.ToString(), true);
        //FormsAuthentication.RedirectFromLoginPage(user.ProviderUserKey.ToString(), true);
         
        if (!this.User.IsInRole(@"")) { return; }
    }


</script>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Title</title>
    </head>
    <body>
        <form id="HtmlForm" runat="server">
            <div>
                
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
                
            </div>
        </form>
    </body>
</html>
