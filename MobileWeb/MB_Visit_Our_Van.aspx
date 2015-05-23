<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Inner_Page_MB_MasterPage.Master" AutoEventWireup="true" CodeBehind="MB_Visit_Our_Van.aspx.cs" Inherits="MobileWeb.MB_Visit_Our_Van" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>Fritzy Fresh Van</h1>
        </div>
    </div>
    <div class="homebanner1">
        <script type="text/javascript" defer="defer">


            var ultimateshow = new Array()


            ultimateshow[0] = ['Images/1.png', '', '']
            ultimateshow[1] = ['Images/2.png', '', '_new']
            ultimateshow[2] = ['Images/3.png', '', '']
            ultimateshow[3] = ['Images/4.png', '', '']


            var slidewidth = "320"
            var slideheight = "142"
            var slidecycles = "3"
            var randomorder = "no"
            var preloadimages = "yes"
            var slidebgcolor = ''

            var slidedelay = 3000


            var ie = document.all
            var dom = document.getElementById
            var curcycle = 0

            if (preloadimages == "yes") {
                for (i = 0; i < ultimateshow.length; i++) {
                    var cacheimage = new Image()
                    cacheimage.src = ultimateshow[i][0]
                }
            }

            var currentslide = 0

            function randomize(targetarray) {
                ultimateshowCopy = new Array()
                var the_one
                var z = 0
                while (z < targetarray.length) {
                    the_one = Math.floor(Math.random() * targetarray.length)
                    if (targetarray[the_one] != "_selected!") {
                        ultimateshowCopy[z] = targetarray[the_one]
                        targetarray[the_one] = "_selected!"
                        z++
                    }
                }
            }

            if (randomorder == "yes")
                randomize(ultimateshow)
            else
                ultimateshowCopy = ultimateshow

            function rotateimages() {
                curcycle = (currentslide == 0) ? curcycle + 1 : curcycle
                ultcontainer = '<center>'
                if (ultimateshowCopy[currentslide][1] != "")
                    ultcontainer += '<a href="' + ultimateshowCopy[currentslide][1] + '" target="' + ultimateshowCopy[currentslide][2] + '">'
                ultcontainer += '<img src="' + ultimateshowCopy[currentslide][0] + '" border="0" height="142" width="320">'
                if (ultimateshowCopy[currentslide][1] != "")
                    ultcontainer += '</a>'
                ultcontainer += '</center>'
                if (ie || dom)
                    crossrotateobj.innerHTML = ultcontainer
                if (currentslide == ultimateshow.length - 1) currentslide = 0
                else currentslide++
                if (curcycle == parseInt(slidecycles) && currentslide == 0)
                    return
                setTimeout("rotateimages()", slidedelay)
            }

            if (ie || dom)
                document.write('<div id="slidedom" style="width:' + slidewidth + ';height:' + slideheight + '; background-color:' + slidebgcolor + '"></div>')

            function start_slider() {
                crossrotateobj = dom ? document.getElementById("slidedom") : document.all.slidedom
                rotateimages()
            }

            if (ie || dom)
                window.onload = start_slider

        </script>
    </div>
    <div class="contentinnersection">

        <div class="innercontent">
            <h2><span class="heading">Full Salon on Wheels</span></h2>
            <p>The Fritzy Fresh Van is well stocked with state-of-the-art tools, supplies and equipment. It is fully self-contained with its own water and power supply. The utility area in the rear houses tanks for fresh and used water, plumbing, power distribution and storage. The center section is the “Salon”. On the left is the warm water hydrotub complete with all of the supplies and accessories to perform the bath portion of the Fritzy Fresh Spa Treatment. Directly in the center is the grooming station with a hydraulic table, drying blower, ClipperVac and all of the supplies and accessories to make your pet Fritzy Fresh!</p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBodyEnd" runat="server">
</asp:Content>
