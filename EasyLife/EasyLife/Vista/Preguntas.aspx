<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Preguntas.aspx.cs" Inherits="EasyLife.Vista.Preguntas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Preguntas Frecuentes</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron card card-image" style="background-image: url(https://i.postimg.cc/7hH0y8Lk/Section.png);">
        <div class="text-white text-center py-5 px-4">
            <div class="container">
                <h2 class="display-4"><strong>Preguntas Frecuentes</strong></h2>
                <p class="mx-5 mb-5"><a href="Index.aspx">Home</a> / Preguntas Frecuentes</p>
            </div>
        </div>
    </div>

    <div style="text-align: center; width: 80%; margin: auto; margin-bottom: 4%;">
        <div class="accordion" id="accordionExample">

            <div class="card">
                <div class="card-header" id="headingOne" style="text-align: center;">
                    <h2 class="mb-0">
                        <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                            Pregunta #1
                        </button>
                    </h2>
                </div>
                <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
                    <div class="card-body">
                        <p style="text-align: justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ultricies, diam nec elementum molestie, ex nulla varius nunc, ac tempor
                            odio tellus eget justo. Cras eleifend malesuada augue et iaculis. Mauris blandit lacinia ex eget venenatis. Praesent vehicula, mauris eget
                            tristique volutpat, lectus velit ullamcorper est, eu tincidunt quam urna id neque. Donec ultricies pulvinar convallis. Morbi nulla augue,
                            tincidunt et sagittis et, egestas in urna. Donec id ligula sagittis, dapibus leo nec, rutrum turpis. Nam diam nibh, consequat sit amet neque
                            lacinia, accumsan auctor urna. Ut ac blandit arcu. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer euismod eros ut est placerat,
                            scelerisque tempus risus viverra. Integer scelerisque orci at sem interdum venenatis. Vivamus faucibus mauris ut sollicitudin aliquet. In nec velit
                            sapien. Nam ipsum nisl, suscipit eget augue quis, pharetra tempor nibh. Fusce dapibus efficitur ex, vitae suscipit lacus consectetur vitae.
                            Pellentesque at felis nibh. Nulla vel.
                        </p>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header" id="headingTwo" style="text-align: center;">
                    <h2 class="mb-0">
                        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                            Pregunta #2
                        </button>
                    </h2>
                </div>
                <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                    <div class="card-body">
                        <p style="text-align: justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ultricies, diam nec elementum molestie, ex nulla varius nunc, ac
                        tempor odio tellus eget justo. Cras eleifend malesuada augue et iaculis. Mauris blandit lacinia ex eget venenatis. Praesent vehicula,
                        mauris eget tristique volutpat, lectus velit ullamcorper est, eu tincidunt quam urna id neque. Donec ultricies pulvinar convallis. Morbi
                        nulla augue, tincidunt et sagittis et, egestas in urna. Donec id ligula sagittis, dapibus leo nec, rutrum turpis. Nam diam nibh, consequat
                        sit amet neque lacinia, accumsan auctor urna. Ut ac blandit arcu. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer euismod
                        eros ut est placerat, scelerisque tempus risus viverra. Integer scelerisque orci at sem interdum venenatis. Vivamus faucibus mauris ut
                        sollicitudin aliquet. In nec velit sapien. Nam ipsum nisl, suscipit eget augue quis, pharetra tempor nibh. Fusce dapibus efficitur ex,
                        vitae suscipit lacus consectetur vitae. Pellentesque at felis nibh. Nulla vel.
                        </p>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header" id="headingThree" style="text-align: center;">
                    <h2 class="mb-0">
                        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                            Pregunta #3
                        </button>
                    </h2>
                </div>
                <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                    <div class="card-body">
                        <p style="text-align: justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ultricies, diam nec elementum molestie, ex nulla varius nunc, ac
                        tempor odio tellus eget justo. Cras eleifend malesuada augue et iaculis. Mauris blandit lacinia ex eget venenatis. Praesent vehicula,
                        mauris eget tristique volutpat, lectus velit ullamcorper est, eu tincidunt quam urna id neque. Donec ultricies pulvinar convallis. Morbi
                        nulla augue, tincidunt et sagittis et, egestas in urna. Donec id ligula sagittis, dapibus leo nec, rutrum turpis. Nam diam nibh, consequat
                        sit amet neque lacinia, accumsan auctor urna. Ut ac blandit arcu. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer euismod
                        eros ut est placerat, scelerisque tempus risus viverra. Integer scelerisque orci at sem interdum venenatis. Vivamus faucibus mauris ut
                        sollicitudin aliquet. In nec velit sapien. Nam ipsum nisl, suscipit eget augue quis, pharetra tempor nibh. Fusce dapibus efficitur ex,
                        vitae suscipit lacus consectetur vitae. Pellentesque at felis nibh. Nulla vel.
                        </p>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header" id="headingFour" style="text-align: center;">
                    <h2 class="mb-0">
                        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseFour" aria-expanded="false" aria-controls="collapseThree">
                            Pregunta #4
                        </button>
                    </h2>
                </div>
                <div id="collapseFour" class="collapse" aria-labelledby="headingFour" data-parent="#accordionExample">
                    <div class="card-body">
                        <p style="text-align: justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ultricies, diam nec elementum molestie, ex nulla varius nunc, ac tempor
                        odio tellus eget justo. Cras eleifend malesuada augue et iaculis. Mauris blandit lacinia ex eget venenatis. Praesent vehicula, mauris eget
                        tristique volutpat, lectus velit ullamcorper est, eu tincidunt quam urna id neque. Donec ultricies pulvinar convallis. Morbi nulla augue,
                        tincidunt et sagittis et, egestas in urna. Donec id ligula sagittis, dapibus leo nec, rutrum turpis. Nam diam nibh, consequat sit amet neque
                        lacinia, accumsan auctor urna. Ut ac blandit arcu. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer euismod eros ut est placerat,
                        scelerisque tempus risus viverra. Integer scelerisque orci at sem interdum venenatis. Vivamus faucibus mauris ut sollicitudin aliquet. In nec
                        velit sapien. Nam ipsum nisl, suscipit eget augue quis, pharetra tempor nibh. Fusce dapibus efficitur ex, vitae suscipit lacus consectetur vitae.
                        Pellentesque at felis nibh. Nulla vel.
                        </p>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header" id="headingFive" style="text-align: center;">
                    <h2 class="mb-0">
                        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseFive" aria-expanded="false" aria-controls="collapseThree">
                            Pregunta #5
                        </button>
                    </h2>
                </div>
                <div id="collapseFive" class="collapse" aria-labelledby="headingFive" data-parent="#accordionExample">
                    <div class="card-body">
                        <p style="text-align: justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ultricies, diam nec elementum molestie, ex nulla varius nunc, ac tempor
                        odio tellus eget justo. Cras eleifend malesuada augue et iaculis. Mauris blandit lacinia ex eget venenatis. Praesent vehicula, mauris eget
                        tristique volutpat, lectus velit ullamcorper est, eu tincidunt quam urna id neque. Donec ultricies pulvinar convallis. Morbi nulla augue, tincidunt
                        et sagittis et, egestas in urna. Donec id ligula sagittis, dapibus leo nec, rutrum turpis. Nam diam nibh, consequat sit amet neque lacinia,
                        accumsan auctor urna. Ut ac blandit arcu. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer euismod eros ut est placerat,
                        scelerisque tempus risus viverra. Integer scelerisque orci at sem interdum venenatis. Vivamus faucibus mauris ut sollicitudin aliquet. In nec
                        velit sapien. Nam ipsum nisl, suscipit eget augue quis, pharetra tempor nibh. Fusce dapibus efficitur ex, vitae suscipit lacus consectetur vitae.
                        Pellentesque at felis nibh. Nulla vel.
                        </p>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header" id="headingSix" style="text-align: center;">
                    <h2 class="mb-0">
                        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseSix" aria-expanded="false" aria-controls="collapseThree">
                            Pregunta #6
                        </button>
                    </h2>
                </div>
                <div id="collapseSix" class="collapse" aria-labelledby="headingSix" data-parent="#accordionExample">
                    <div class="card-body">
                        <p style="text-align: justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ultricies, diam nec elementum molestie, ex nulla varius nunc, ac tempor
                        odio tellus eget justo. Cras eleifend malesuada augue et iaculis. Mauris blandit lacinia ex eget venenatis. Praesent vehicula, mauris eget
                        tristique volutpat, lectus velit ullamcorper est, eu tincidunt quam urna id neque. Donec ultricies pulvinar convallis. Morbi nulla augue,
                        tincidunt et sagittis et, egestas in urna. Donec id ligula sagittis, dapibus leo nec, rutrum turpis. Nam diam nibh, consequat sit amet neque
                        lacinia, accumsan auctor urna. Ut ac blandit arcu. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer euismod eros ut est placerat,
                        scelerisque tempus risus viverra. Integer scelerisque orci at sem interdum venenatis. Vivamus faucibus mauris ut sollicitudin aliquet. In nec velit
                        sapien. Nam ipsum nisl, suscipit eget augue quis, pharetra tempor nibh. Fusce dapibus efficitur ex, vitae suscipit lacus consectetur vitae.
                        Pellentesque at felis nibh. Nulla vel.
                        </p>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header" id="headingSeven" style="text-align: center;">
                    <h2 class="mb-0">
                        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseSeven" aria-expanded="false" aria-controls="collapseThree">
                            Pregunta #7
                        </button>
                    </h2>
                </div>
                <div id="collapseSeven" class="collapse" aria-labelledby="headingSeven" data-parent="#accordionExample">
                    <div class="card-body">
                        <p style="text-align: justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ultricies, diam nec elementum molestie, ex nulla varius nunc, ac tempor
                        odio tellus eget justo. Cras eleifend malesuada augue et iaculis. Mauris blandit lacinia ex eget venenatis. Praesent vehicula, mauris eget
                        tristique volutpat, lectus velit ullamcorper est, eu tincidunt quam urna id neque. Donec ultricies pulvinar convallis. Morbi nulla augue,
                        tincidunt et sagittis et, egestas in urna. Donec id ligula sagittis, dapibus leo nec, rutrum turpis. Nam diam nibh, consequat sit amet neque
                        lacinia, accumsan auctor urna. Ut ac blandit arcu. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer euismod eros ut est placerat,
                        scelerisque tempus risus viverra. Integer scelerisque orci at sem interdum venenatis. Vivamus faucibus mauris ut sollicitudin aliquet. In nec
                        velit sapien. Nam ipsum nisl, suscipit eget augue quis, pharetra tempor nibh. Fusce dapibus efficitur ex, vitae suscipit lacus consectetur vitae.
                        Pellentesque at felis nibh. Nulla vel.
                        </p>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header" id="headingEight" style="text-align: center;">
                    <h2 class="mb-0">
                        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseEight" aria-expanded="false" aria-controls="collapseThree">
                            Pregunta #8
                        </button>
                    </h2>
                </div>
                <div id="collapseEight" class="collapse" aria-labelledby="headingEight" data-parent="#accordionExample">
                    <div class="card-body">
                        <p style="text-align: justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ultricies, diam nec elementum molestie, ex nulla varius nunc, ac tempor
                        odio tellus eget justo. Cras eleifend malesuada augue et iaculis. Mauris blandit lacinia ex eget venenatis. Praesent vehicula, mauris eget
                        tristique volutpat, lectus velit ullamcorper est, eu tincidunt quam urna id neque. Donec ultricies pulvinar convallis. Morbi nulla augue,
                        tincidunt et sagittis et, egestas in urna. Donec id ligula sagittis, dapibus leo nec, rutrum turpis. Nam diam nibh, consequat sit amet neque
                        lacinia, accumsan auctor urna. Ut ac blandit arcu. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer euismod eros ut est placerat,
                        scelerisque tempus risus viverra. Integer scelerisque orci at sem interdum venenatis. Vivamus faucibus mauris ut sollicitudin aliquet. In nec
                        velit sapien. Nam ipsum nisl, suscipit eget augue quis, pharetra tempor nibh. Fusce dapibus efficitur ex, vitae suscipit lacus consectetur vitae.
                        Pellentesque at felis nibh. Nulla vel.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>