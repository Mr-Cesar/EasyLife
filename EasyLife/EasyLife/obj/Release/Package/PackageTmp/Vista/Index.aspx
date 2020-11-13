<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EasyLife.Vista.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Index</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Slider -->
    <section>
        <!--Carousel Wrapper-->
        <div id="carousel-example-1z" class="carousel slide carousel-fade" data-ride="carousel">
            <!--Indicators-->
            <ol class="carousel-indicators">
                <li data-target="#carousel-example-1z" data-slide-to="0" class="active"></li>
                <li data-target="#carousel-example-1z" data-slide-to="1"></li>
                <li data-target="#carousel-example-1z" data-slide-to="2"></li>
            </ol>
            <!--/.Indicators-->
            <!--Slides-->
            <div class="carousel-inner" role="listbox">
                <!--First slide-->
                <div class="carousel-item active">
                    <img class="d-block w-100" src="https://i.postimg.cc/PJpVYwmJ/Slider-1.jpg" alt="First slide" style="height: 500px">
                    <div class="carousel-caption d-none d-md-block">
                        <h5>First slide label</h5>
                        <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                    </div>
                </div>
                <!--/First slide-->
                <!--Second slide-->
                <div class="carousel-item">
                    <img class="d-block w-100" src="https://i.postimg.cc/XJDDr8Bt/Slider-2.jpg" alt="Second slide" style="height: 500px">
                    <div class="carousel-caption d-none d-md-block">
                        <h5>Second slide label</h5>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    </div>
                </div>
                <!--/Second slide-->
                <!--Third slide-->
                <div class="carousel-item">
                    <img class="d-block w-100" src="https://i.postimg.cc/fyG2KRKK/Slider-3.jpg" alt="Third slide" style="height: 500px">
                    <div class="carousel-caption d-none d-md-block">
                        <h5>Third slide label</h5>
                        <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                    </div>
                </div>
                <!--/Third slide-->
            </div>
            <!--/.Slides-->
            <!--Controls-->
            <a class="carousel-control-prev" href="#carousel-example-1z" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carousel-example-1z" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
            <!--/.Controls-->
        </div>
        <!--/.Carousel Wrapper-->
    </section>

    <!-- Seccion de noticias -->
    <section style="text-align: center; margin-bottom: 30px;">
        <div class="card" style="width: 18rem; display: inline-block; margin: 20px;">
            <img src="https://mdbootstrap.com/img/Photos/Slides/img%20(130).jpg" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                <asp:Button ID="Button1" runat="server" Text="Go somewhere" CssClass="btn btn-primary" />
            </div>
        </div>

        <div class="card" style="width: 18rem; display: inline-block; margin: 20px;">
            <img src="https://mdbootstrap.com/img/Photos/Slides/img%20(130).jpg" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                <asp:Button ID="Button2" runat="server" Text="Go somewhere" CssClass="btn btn-primary" />
            </div>
        </div>

        <div class="card" style="width: 18rem; display: inline-block; margin: 20px;">
            <img src="https://mdbootstrap.com/img/Photos/Slides/img%20(130).jpg" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                <asp:Button ID="Button3" runat="server" Text="Go somewhere" CssClass="btn btn-primary" />
            </div>
        </div>

        <div class="card" style="width: 18rem; display: inline-block; margin: 20px;">
            <img src="https://mdbootstrap.com/img/Photos/Slides/img%20(130).jpg" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                <asp:Button ID="Button4" runat="server" Text="Go somewhere" CssClass="btn btn-primary" />
            </div>
        </div>
    </section>

    <section style="text-align: center; margin-bottom: 30px;">
        <div class="card" style="width: 18rem; display: inline-block; margin: 20px;">
            <img src="https://mdbootstrap.com/img/Photos/Slides/img%20(130).jpg" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                <asp:Button ID="Button5" runat="server" Text="Go somewhere" CssClass="btn btn-primary" />
            </div>
        </div>

        <div class="card" style="width: 18rem; display: inline-block; margin: 20px;">
            <img src="https://mdbootstrap.com/img/Photos/Slides/img%20(130).jpg" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                <asp:Button ID="Button6" runat="server" Text="Go somewhere" CssClass="btn btn-primary" />
            </div>
        </div>

        <div class="card" style="width: 18rem; display: inline-block; margin: 20px;">
            <img src="https://mdbootstrap.com/img/Photos/Slides/img%20(130).jpg" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                <asp:Button ID="Button7" runat="server" Text="Go somewhere" CssClass="btn btn-primary" />
            </div>
        </div>

        <div class="card" style="width: 18rem; display: inline-block; margin: 20px;">
            <img src="https://mdbootstrap.com/img/Photos/Slides/img%20(130).jpg" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                <asp:Button ID="Button8" runat="server" Text="Go somewhere" CssClass="btn btn-primary" />
            </div>
        </div>
    </section>
</asp:Content>