function setList(i) {
    debugger;
    switch (i) {
        case 1:

            var val = document.getElementById("ctl00_cntBody_lstAddservices1");
            alert(document.getElementById('<%=lstAddservices1.ClientID%>'));
            if (val.style.display == "none") {
                val.style.display = "block";
                val.focus();
            }
            else {
                val.style.display = "none";
            }
            return false;

            function HideList(i) {
                val.style.display = "none";
                return false;
            }

            function SetText(i) {
                var Source = document.getElementById('<%=lstAddservices1.ClientID%>');
                var str = "";
                var str1 = "";
                //alert(Source.options.selectedIndex);
                for (j = 0; j < document.getElementById('<%=lstAddservices1.ClientID%>').length; j++) {
                    if (Source.options[j].selected) {
                        if (str == "") {
                            str = Source.options[j].text;
                            str1 = Source.options[j].value;
                        }
                        else {
                            str = str + "," + Source.options[j].text;
                            str1 = str1 + "," + Source.options[j].value;
                        }
                    }
                }

                document.getElementById("txtAddServices" + i).value = str;
                document.getElementById("txtAddServicesID" + i).value = str1;


            }
            break;

        case 2:
            if (document.getElementById('<%=lstAddservices2.ClientID%>').style.display == "none") {
                document.getElementById('<%=lstAddservices2.ClientID%>').style.display = "block";
                document.getElementById('<%=lstAddservices2.ClientID%>').focus();
            }
            else {
                document.getElementById('<%=lstAddservices2.ClientID%>').style.display = "none";
            }
            return false;

            function HideList(i) {
                document.getElementById('<%=lstAddservices2.ClientID%>').style.display = "none";
                return false;
            }

            function SetText(i) {
                var Source = document.getElementById('<%=lstAddservices2.ClientID%>');
                var str = "";
                var str1 = "";
                //alert(Source.options.selectedIndex);
                for (j = 0; j < document.getElementById('<%=lstAddservices2.ClientID%>').length; j++) {
                    if (Source.options[j].selected) {
                        if (str == "") {
                            str = Source.options[j].text;
                            str1 = Source.options[j].value;
                        }
                        else {
                            str = str + "," + Source.options[j].text;
                            str1 = str1 + "," + Source.options[j].value;
                        }
                    }
                }

                document.getElementById("txtAddServices" + i).value = str;
                document.getElementById("txtAddServicesID" + i).value = str1;


            }
            break;

        case 3:
            if (document.getElementById('<%=lstAddservices3.ClientID%>').style.display == "none") {
                document.getElementById('<%=lstAddservices3.ClientID%>').style.display = "block";
                document.getElementById('<%=lstAddservices3.ClientID%>').focus();
            }
            else {
                document.getElementById('<%=lstAddservices3.ClientID%>').style.display = "none";
            }
            return false;

            function HideList(i) {
                document.getElementById('<%=lstAddservices3.ClientID%>').style.display = "none";
                return false;
            }

            function SetText(i) {
                var Source = document.getElementById('<%=lstAddservices3.ClientID%>');
                var str = "";
                var str1 = "";
                //alert(Source.options.selectedIndex);
                for (j = 0; j < document.getElementById('<%=lstAddservices3.ClientID%>').length; j++) {
                    if (Source.options[j].selected) {
                        if (str == "") {
                            str = Source.options[j].text;
                            str1 = Source.options[j].value;
                        }
                        else {
                            str = str + "," + Source.options[j].text;
                            str1 = str1 + "," + Source.options[j].value;
                        }
                    }
                }

                document.getElementById("txtAddServices" + i).value = str;
                document.getElementById("txtAddServicesID" + i).value = str1;


            }
            break;

        case 4:
            if (document.getElementById('<%=lstAddservices4.ClientID%>').style.display == "none") {
                document.getElementById('<%=lstAddservices4.ClientID%>').style.display = "block";
                document.getElementById('<%=lstAddservices4.ClientID%>').focus();
            }
            else {
                document.getElementById('<%=lstAddservices4.ClientID%>').style.display = "none";
            }
            return false;

            function HideList(i) {
                document.getElementById('<%=lstAddservices4.ClientID%>').style.display = "none";
                return false;
            }

            function SetText(i) {
                var Source = document.getElementById('<%=lstAddservices4.ClientID%>');
                var str = "";
                var str1 = "";
                //alert(Source.options.selectedIndex);
                for (j = 0; j < document.getElementById('<%=lstAddservices4.ClientID%>').length; j++) {
                    if (Source.options[j].selected) {
                        if (str == "") {
                            str = Source.options[j].text;
                            str1 = Source.options[j].value;
                        }
                        else {
                            str = str + "," + Source.options[j].text;
                            str1 = str1 + "," + Source.options[j].value;
                        }
                    }
                }

                document.getElementById("txtAddServices" + i).value = str;
                document.getElementById("txtAddServicesID" + i).value = str1;


            }
            break;

        case 5:
            if (document.getElementById('<%=lstAddservices5.ClientID%>').style.display == "none") {
                document.getElementById('<%=lstAddservices5.ClientID%>').style.display = "block";
                document.getElementById('<%=lstAddservices5.ClientID%>').focus();
            }
            else {
                document.getElementById('<%=lstAddservices5.ClientID%>').style.display = "none";
            }
            return false;

            function HideList(i) {
                document.getElementById('<%=lstAddservices5.ClientID%>').style.display = "none";
                return false;
            }

            function SetText(i) {
                var Source = document.getElementById('<%=lstAddservices5.ClientID%>');
                var str = "";
                var str1 = "";
                //alert(Source.options.selectedIndex);
                for (j = 0; j < document.getElementById('<%=lstAddservices5.ClientID%>').length; j++) {
                    if (Source.options[j].selected) {
                        if (str == "") {
                            str = Source.options[j].text;
                            str1 = Source.options[j].value;
                        }
                        else {
                            str = str + "," + Source.options[j].text;
                            str1 = str1 + "," + Source.options[j].value;
                        }
                    }
                }

                document.getElementById("txtAddServices" + i).value = str;
                document.getElementById("txtAddServicesID" + i).value = str1;


            }
            break;

        case 6:
            if (document.getElementById('<%=lstAddservices6.ClientID%>').style.display == "none") {
                document.getElementById('<%=lstAddservices6.ClientID%>').style.display = "block";
                document.getElementById('<%=lstAddservices6.ClientID%>').focus();
            }
            else {
                document.getElementById('<%=lstAddservices6.ClientID%>').style.display = "none";
            }
            return false;

            function HideList(i) {
                document.getElementById('<%=lstAddservices6.ClientID%>').style.display = "none";
                return false;
            }

            function SetText(i) {
                var Source = document.getElementById('<%=lstAddservices6.ClientID%>');
                var str = "";
                var str1 = "";
                //alert(Source.options.selectedIndex);
                for (j = 0; j < document.getElementById('<%=lstAddservices6.ClientID%>').length; j++) {
                    if (Source.options[j].selected) {
                        if (str == "") {
                            str = Source.options[j].text;
                            str1 = Source.options[j].value;
                        }
                        else {
                            str = str + "," + Source.options[j].text;
                            str1 = str1 + "," + Source.options[j].value;
                        }
                    }
                }

                document.getElementById("txtAddServices" + i).value = str;
                document.getElementById("txtAddServicesID" + i).value = str1;


            }
            break;
    }
}